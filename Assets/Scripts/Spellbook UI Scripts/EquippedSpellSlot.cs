using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquippedSpellSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] Spell spell = null;
    [SerializeField] ActiveSpellSlot activeSpellSlot;

    SpellDisplay spellDisplay;


    private void Start() {

        spellDisplay = this.GetComponent<SpellDisplay>();

        if (spell != null)
        {
            spellDisplay.setSpell(spell);

            activeSpellSlot.setSpell(spell);
        }
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedSpell = eventData.pointerDrag;


        if (droppedSpell.gameObject.tag == "KnownSpell" || droppedSpell.gameObject.tag == "EquippedSpell")
        {
            spell = droppedSpell.GetComponent<SpellDisplay>().getSpell();
            spellDisplay.setSpell(spell);
            activeSpellSlot.setSpell(spell);
        }

        if (droppedSpell.gameObject.tag == "Element")
        {
            spell = droppedSpell.GetComponent<SpellDisplay>().getSpell();
            spellDisplay.setSpell(spell);
            activeSpellSlot.setSpell(spell);
        }
    }
}
