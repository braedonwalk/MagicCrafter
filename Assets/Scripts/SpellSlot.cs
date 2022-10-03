using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellSlot : MonoBehaviour, IDropHandler
{
    
    Image image;
    Spell spell = null;


    private void Start() {
        image = this.GetComponent<Image>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        GameObject droppedSpell = eventData.pointerDrag;

        Debug.Log(this.spell);
        spell = droppedSpell.GetComponent<SpellDisplay>().getSpell();
        image.sprite = droppedSpell.GetComponent<Image>().sprite;
        Debug.Log(this.spell);
    }
}
