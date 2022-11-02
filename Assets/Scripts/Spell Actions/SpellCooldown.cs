using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCooldown : MonoBehaviour
{
    Spell activeSpell;
    bool startCooldown;
    float cooldownTime;
    float cooldownTimer = 0f;
    bool canCast = true;

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            SpellAction spellAction = gameObject.GetComponent<SpellAction>();
            activeSpell = spellAction.getActiveSpell();  //NullReferenceException: Object reference not set to an instance of an object????
            cooldownTime = activeSpell.cooldown;
            UseSpell();
            // Debug.Log(this.GetType());
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
        }
        else{
        }
    }

    void UseSpell()
    {
        if(!startCooldown)
        {
            canCast = true;
            startCooldown = true;
            cooldownTimer = cooldownTime;
        }
        else
        {
            canCast = false;
        }
    }

    public bool getCanCast()
    {
        return canCast;
    }

}
