using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellDisplay : MonoBehaviour
{
    
    [SerializeField] Spell spell;

    // [SerializeField] Text spellName;
    [SerializeField] Image image;   //setup in start?
    [SerializeField] ElementPickup pickUp;

    public static SpellDisplay Instance {get; private set;} // not used now

    
    void Start()
    {
        // image.sprite = spell.sprite;
    }

    private void Update() {
        //if element1True {image.sprite = spell.sprite;}
        if(pickUp.getPickUp())
        {
            image.sprite = spell.sprite;
        }
    }

    //create a reference to another script that checks a bool whether the outside element has been picked up or not

    public Spell getSpell()
    {
        return spell;
    }


}
