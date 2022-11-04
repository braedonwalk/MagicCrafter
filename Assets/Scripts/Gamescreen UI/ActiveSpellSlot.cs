using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSpellSlot : MonoBehaviour
{
    
   SpellDisplay spellDisplay;

   [SerializeField] Slot equipSlot;

   CanvasGroup canvasGroup;

   [SerializeField] bool isActive = false;
   //is active bool
   //in inputmanager, when setting active spell, also reset all bools false except activeSlot true
    
    // Start is called before the first frame update

     void OnEnable() 
     {
        spellDisplay = this.GetComponent<SpellDisplay>();
        spellDisplay.setSpell(equipSlot.GetComponent<SpellDisplay>().getSpell());   
    }

    void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();

        if (!isActive)
        {
            canvasGroup.alpha = 0.3f;
        }
    }

    private void Update() {
        spellDisplay.setSpell(equipSlot.GetComponent<SpellDisplay>().getSpell());
    }

    public void setAlpha(float newAlpha)
    {
        canvasGroup.alpha = newAlpha;
    }

    public bool setActiveSlot(bool state)
    {
        // isActive = state;
        return isActive = state;
    }

    public bool getIsActive()
    {
        return isActive;
    }
}
