using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public void makeBurnEffect(GameObject otherGameObject, Spell aSpell)
    {
        float newRed = otherGameObject.GetComponent<SpriteRenderer>().color.r - 0.25f;
        float newGreen = otherGameObject.GetComponent<SpriteRenderer>().color.g - 0.4f;
        float newBlue = otherGameObject.GetComponent<SpriteRenderer>().color.b - 0.4f;

        newRed = Mathf.Clamp(newRed, 0.2f, 255);
        newGreen = Mathf.Clamp(newGreen, 0.2f, 255);
        newBlue = Mathf.Clamp(newBlue, 0.2f, 255);

        otherGameObject.GetComponent<SpriteRenderer>().color = new Color(newRed, newGreen, newBlue);

        if (newRed > 0)
        {
            Instantiate(aSpell.effectPrefab, otherGameObject.transform);
        }
    }

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
        Instantiate(aSpell.effectPrefab, this.transform);
    }
}
