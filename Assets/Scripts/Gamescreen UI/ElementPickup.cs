using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPickup : MonoBehaviour
{

    bool isPickUp = false;

    [SerializeField] SpellDisplay draggableSpellDisplay;
    [SerializeField] SpellDisplay stillSpellDisplay;
    
    
    [SerializeField] Spell spell;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("pickup");
            isPickUp = true;
            draggableSpellDisplay.setSpell(spell);
            stillSpellDisplay.setSpell(spell);
        }
    }

    public bool getPickUp()
    {
        return isPickUp;
    }
}
