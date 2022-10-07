using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquippedSpellSlot : MonoBehaviour, IDropHandler
{
    Image image;
    Spell spell = null;

    private void Start() {
        image = this.GetComponent<Image>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedSpell = eventData.pointerDrag;


        if (droppedSpell.gameObject.tag == "KnownSpell" || droppedSpell.gameObject.tag == "EquippedSpell")
        {
            spell = droppedSpell.GetComponent<KnownSpellSlot>().getSpell();
            image.sprite = droppedSpell.GetComponent<Image>().sprite;
        }
    }

    public Spell getSpell(){
        return spell;
    }
}
