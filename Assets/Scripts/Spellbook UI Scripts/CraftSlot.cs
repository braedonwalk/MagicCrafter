using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour, IDropHandler
{
    
    Image image;
    Spell spell = null;

    SpellDisplay spellDisplay;


    private void Start() {
        image = this.GetComponent<Image>();
        spellDisplay = this.GetComponent<SpellDisplay>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedSpell = eventData.pointerDrag;

        if (droppedSpell.gameObject.tag == "Element")
        {
            // spell = droppedSpell.GetComponent<SpellDisplay>().getSpell();
            // image.sprite = droppedSpell.GetComponent<Image>().sprite;

            spellDisplay.setSpell(droppedSpell.GetComponent<SpellDisplay>().getSpell());
        }
    }

    public Spell getSpell(){
        return spell;
    }
}
