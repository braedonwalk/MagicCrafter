using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    
    SpellDisplay spellDisplay;

    [SerializeField] String[] receiveTags;


    private void Start() {
        spellDisplay = this.GetComponent<SpellDisplay>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedSpell = eventData.pointerDrag;

        foreach (String tag in receiveTags)
        {

            if (droppedSpell.gameObject.tag == tag)
            {
                spellDisplay.setSpell(droppedSpell.GetComponent<SpellDisplay>().getSpell());
            }

        }
    }
}
