using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSpellSlot : MonoBehaviour
{
    
   SpellDisplay spellDisplay;

   [SerializeField] Slot equipSlot;
    
    // Start is called before the first frame update
    void Start()
    {
        spellDisplay = this.GetComponent<SpellDisplay>();

        spellDisplay.setSpell(equipSlot.GetComponent<SpellDisplay>().getSpell());
    }

    private void Update() {
        spellDisplay.setSpell(equipSlot.GetComponent<SpellDisplay>().getSpell());
    }
}
