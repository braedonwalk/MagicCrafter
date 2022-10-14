using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquippedSpellSlot : MonoBehaviour, IDropHandler
{
    Image image;
    [SerializeField] Spell spell = null;
    [SerializeField] ActiveSpellSlot activeSpellSlot;

    SpellDisplay spellDisplay;


    private void Start() {
        image = this.GetComponent<Image>();

        spellDisplay = this.GetComponent<SpellDisplay>();

        if (spell != null)
        {
            image.sprite = spell.sprite;

            activeSpellSlot.setSpell(spell);
        }
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedSpell = eventData.pointerDrag;


        if (droppedSpell.gameObject.tag == "KnownSpell" || droppedSpell.gameObject.tag == "EquippedSpell")
        {
            spell = droppedSpell.GetComponent<KnownSpellSlot>().getSpell();
            image.sprite = droppedSpell.GetComponent<Image>().sprite;

            activeSpellSlot.setSpell(spell);
        }

        if (droppedSpell.gameObject.tag == "Element")
        {
            spell = droppedSpell.GetComponent<SpellDisplay>().getSpell();
            image.sprite = droppedSpell.GetComponent<Image>().sprite;

            activeSpellSlot.setSpell(spell);
        }
    }

    public Spell getSpell(){
        return spell;
    }
}
