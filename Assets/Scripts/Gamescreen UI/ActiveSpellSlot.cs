using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSpellSlot : MonoBehaviour
{
    
   SpellDisplay spellDisplay;

   [SerializeField] Slot equipSlot;

   CanvasGroup canvasGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        spellDisplay = this.GetComponent<SpellDisplay>();

        spellDisplay.setSpell(equipSlot.GetComponent<SpellDisplay>().getSpell());

        canvasGroup = this.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0.3f;
    }

    private void Update() {
        spellDisplay.setSpell(equipSlot.GetComponent<SpellDisplay>().getSpell());
    }

    public void setAlpha(float newAlpha)
    {
        canvasGroup.alpha = newAlpha;
    }
}
