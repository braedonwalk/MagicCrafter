using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCooldown : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown;
    // [SerializeField]
    // private TMP_Text textCooldown;

    bool isCooldown;
    float cooldownTime = 10f;
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
            UseSpell();
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

}
