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


    private void Start() {
        image = this.GetComponent<Image>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedSpell = eventData.pointerDrag;

        if (droppedSpell.gameObject.tag == "Element"){
            spell = droppedSpell.GetComponent<SpellDisplay>().getSpell();
            image.sprite = droppedSpell.GetComponent<Image>().sprite;
        }
    }

    public Spell getSpell(){
        return spell;
    }
}
