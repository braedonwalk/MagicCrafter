using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    
    // to be used by SpellCollision script
    
    public void makeBurnEffect(GameObject otherGameObject, Spell aSpell)
    {
        changeSpriteColor(otherGameObject, -0.25f, -0.4f, -0.4f);
        float spriteRed = otherGameObject.GetComponent<SpriteRenderer>().color.r;

        if (spriteRed > 0.2f)
        {
            Instantiate(aSpell.effectPrefab, otherGameObject.transform);
        }
    }

    public void makeSlowEffect(GameObject aGameObject, Spell aSpell)
    {
        changeSpriteColor(aGameObject, 0.2f, 0.2f, -0.4f);
    }

    void changeSpriteColor(GameObject aGameObject, float redChange, float greenChange, float blueChange)
    {
        float newRed = aGameObject.GetComponent<SpriteRenderer>().color.r + redChange;
        float newGreen = aGameObject.GetComponent<SpriteRenderer>().color.g + greenChange;
        float newBlue = aGameObject.GetComponent<SpriteRenderer>().color.b + blueChange;

        newRed = Mathf.Clamp(newRed, 0.2f, 1.0f);
        newGreen = Mathf.Clamp(newGreen, 0.2f, 1.0f);
        newBlue = Mathf.Clamp(newBlue, 0.2f, 1.0f);

        aGameObject.GetComponent<SpriteRenderer>().color = new Color(newRed, newGreen, newBlue);
    }

    // to be used on self

    // TODO: refactor this to just use the makeBurnEffect function with this.gameobject as the first parameter
    // do NOT use makeBurnEffect on player - we do not want to change the color of the sprite
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

    //collision FX
    // [SerializeField] GameObject fireHitFX;
    // public void fireHit(GameObject gameObject)
    // {
    //     Instantiate(fireHitFX, gameObject.GetComponent<Transform>());
    //     Debug.Log("Fire Hit");
    // }

}
