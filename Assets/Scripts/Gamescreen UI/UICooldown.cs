using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICooldown : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown;
    // [SerializeField]
    // private TMP_Text textCooldown;
    ActiveSpellSlot activeSpellSlot;

    Spell activeSpell;
    bool startCooldown;
    float cooldownTime;
    float cooldownTimer = 0f;

    private void Start() 
    {
        // textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0f;
        activeSpellSlot = GetComponent<ActiveSpellSlot>();
    }

    private void Update() 
    {
        // Debug.Log(activeSpellSlot.name + activeSpellSlot.getIsActive());
        if(Input.GetButtonDown("Fire1"))
        {
            if (activeSpellSlot.getIsActive())
            {
                SpellDisplay spellDisplay = gameObject.GetComponent<SpellDisplay>();
                activeSpell = spellDisplay.getSpell();
                cooldownTime = activeSpell.cooldown;
                UseSpell();
                // Debug.Log(activeSpellSlot.getIsActive());
                // Debug.Log(this.GetType());
            }
        }
        if(startCooldown)
        {
            ApplyCooldown();
        }   
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer < 0f)
        {
            startCooldown = false;
            // textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0f;
        }
        else{
            // textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    void UseSpell()
    {
        if(!startCooldown)
        {
            startCooldown = true;
            // textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
        }
        else
        {
            
        }
    }

    public bool getIsCooldown()
    {
        return startCooldown;
    }
}
