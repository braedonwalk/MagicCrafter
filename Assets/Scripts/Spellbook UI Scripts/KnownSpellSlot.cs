using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KnownSpellSlot : MonoBehaviour, IDropHandler
{
    SpellDisplay spellDisplay;



    private void Start() {        
        spellDisplay = this.GetComponent<SpellDisplay>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedSpell = eventData.pointerDrag;


        if (droppedSpell.gameObject.tag == "ResultSpell")
        {
            spellDisplay.setSpell(droppedSpell.GetComponent<SpellDisplay>().getSpell());
        }
    }
}
