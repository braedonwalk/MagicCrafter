using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour, IDropHandler
{
    
    SpellDisplay spellDisplay;


    private void Start() {
        spellDisplay = this.GetComponent<SpellDisplay>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedSpell = eventData.pointerDrag;

        if (droppedSpell.gameObject.tag == "Element")
        {
            spellDisplay.setSpell(droppedSpell.GetComponent<SpellDisplay>().getSpell());
        }
    }
}
