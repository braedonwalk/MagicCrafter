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

    Spell activeSpell;
    bool isCooldown;
    float cooldownTime;
    float cooldownTimer = 0f;

    private void Start() 
    {
        // textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0f;
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            SpellDisplay spellDisplay = gameObject.GetComponent<SpellDisplay>();
            activeSpell = spellDisplay.getSpell();  //NullReferenceException: Object reference not set to an instance of an object????
            cooldownTime = activeSpell.cooldown;
            UseSpell();
            // Debug.Log(this.GetType());
        }
        if(isCooldown)
        {
            ApplyCooldown();
        }    
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer < 0f)
        {
            isCooldown = false;
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
        if(isCooldown)
        {

        }
        else
        {
            isCooldown = true;
            // textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
        }
    }

    public bool getIsCooldown()
    {
        return isCooldown;
    }
}
