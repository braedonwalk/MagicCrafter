using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    
    SpellDisplay spellDisplay;

    SpellInputManager spellInputManager;

    [SerializeField] String[] receiveTags;


    private void Start() {
        spellDisplay = this.GetComponent<SpellDisplay>();
        spellInputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellInputManager>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {        
        GameObject droppedSpell = eventData.pointerDrag;

        foreach (String tag in receiveTags)
        {

            if (droppedSpell.gameObject.tag == tag)
            {
                Spell newSpell = droppedSpell.GetComponent<SpellDisplay>().getSpell();
                
                spellDisplay.setSpell(newSpell);
                spellInputManager.setActiveSpell(newSpell);
            }

        }
    }
}
