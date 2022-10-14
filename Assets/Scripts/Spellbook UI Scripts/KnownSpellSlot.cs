using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KnownSpellSlot : MonoBehaviour, IDropHandler
{
    Spell spell;

    SpellDisplay spellDisplay;



    private void Start() {        
        spellDisplay = this.GetComponent<SpellDisplay>();

        spell = this.GetComponent<SpellDisplay>().getEmptySpell();

    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedSpell = eventData.pointerDrag;


        if (droppedSpell.gameObject.tag == "ResultSpell")
        {
            spell = droppedSpell.GetComponent<SpellDisplay>().getSpell();
            spellDisplay.setSpell(spell);
        }
    }
}
