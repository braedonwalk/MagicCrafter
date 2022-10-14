using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KnownSpellSlot : MonoBehaviour, IDropHandler
{
    Image image;
    Spell spell;

    private void Start() {
        image = this.GetComponent<Image>();
        spell = this.GetComponent<DragNDrop>().getEmptySpell();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedSpell = eventData.pointerDrag;

        if (droppedSpell.gameObject.tag == "ResultSpell")
        {
            spell = droppedSpell.GetComponent<ResultSlot>().getCurrentSpell();
            image.sprite = droppedSpell.GetComponent<Image>().sprite;
        }
    }

    public Spell getSpell(){
        return spell;
    }
}
