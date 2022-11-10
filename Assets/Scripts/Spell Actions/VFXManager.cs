using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    
    // to be used by SpellCollision script
    
    public void makeBurnEffect(GameObject otherGameObject, Spell aSpell)
    {
        float newRed = otherGameObject.GetComponent<SpriteRenderer>().color.r - 0.25f;
        float newGreen = otherGameObject.GetComponent<SpriteRenderer>().color.g - 0.4f;
        float newBlue = otherGameObject.GetComponent<SpriteRenderer>().color.b - 0.4f;

        newRed = Mathf.Clamp(newRed, 0.2f, 1.0f);
        newGreen = Mathf.Clamp(newGreen, 0.2f, 1.0f);
        newBlue = Mathf.Clamp(newBlue, 0.2f, 1.0f);

        otherGameObject.GetComponent<SpriteRenderer>().color = new Color(newRed, newGreen, newBlue);

        if (newRed > 0)
        {
            Instantiate(aSpell.effectPrefab, otherGameObject.transform);
        }
    }

    public void makeSlowEffect(GameObject aGameObject, Spell aSpell)
    {
        float newRed = aGameObject.GetComponent<SpriteRenderer>().color.r + 0.2f;
        float newGreen = aGameObject.GetComponent<SpriteRenderer>().color.g + 0.2f;
        float newBlue = aGameObject.GetComponent<SpriteRenderer>().color.b - 0.4f;

        newRed = Mathf.Clamp(newRed, 0.2f, 1.0f);
        newGreen = Mathf.Clamp(newGreen, 0.2f, 1.0f);
        newBlue = Mathf.Clamp(newBlue, 0.2f, 1.0f);

        aGameObject.GetComponent<SpriteRenderer>().color = new Color(newRed, newGreen, newBlue);
    }

    // to be used on self

    // TODO: refactor this to just use the makeBurnEffect function with this.gameobject as the first parameter
    public void spontaneousCombustion(Spell aSpell)
    {
        Instantiate(aSpell.effectPrefab, this.transform);
        // particleSystem.renderer.sortingLayerName = "Foreground";    //fix later
    }

    public void increasePlayerSpeed(Spell aSpell)
    {
        Instantiate(aSpell.effectPrefab, this.transform);
    }

    public void decreasePlayerSpeed(Spell aSpell)
    {
        // should you instantiate anything here?
        makeSlowEffect(this.gameObject, aSpell);
    }


}
