using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KnownSpellSlot : MonoBehaviour, IDropHandler
{
    Image image;
    Spell spell;

    SpellDisplay spellDisplay;



    private void Start() {
        image = this.GetComponent<Image>();
        
        spellDisplay = this.GetComponent<SpellDisplay>();

        spell = this.GetComponent<SpellDisplay>().getEmptySpell();

    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedSpell = eventData.pointerDrag;


        if (droppedSpell.gameObject.tag == "ResultSpell")
        {
            spell = droppedSpell.GetComponent<SpellDisplay>().getSpell();
            image.sprite = droppedSpell.GetComponent<Image>().sprite;
        }
    }

    public Spell getSpell(){
        return spell;
    }
}
