using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    
    [SerializeField] Spell spell;
    EnemyHealth enemyHealth;
    SpellAction spellAction;

    private void Start() {
        spellAction = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpellAction>();
    }

    private void OnCollisionEnter2D(Collision2D other) {

        VFXManager vFXManager = other.gameObject.GetComponent<VFXManager>();
        
        if(!other.gameObject.CompareTag("Player"))
        {
            checkElementType(vFXManager);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            // can instantiate effect or play sound here
        }

        if (other.gameObject.tag == "Object")
        {                
            checkEffect(vFXManager, other);
        }

        if (other.gameObject.tag == "Enemy")
        {
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.removeHealth(spell.damage);
        }
        
    }

    void checkEffect(VFXManager vFXManager, Collision2D other)
    {
        if (getIdAttribute(3) == 1) // burning
        {
            vFXManager.makeBurnEffect(other.gameObject, spell);
            // Debug.Log("burnnnnnnn");
        }

        if (getIdAttribute(3) == 2) // wet
        {
            
        }

        if (getIdAttribute(3) == 3) // slow
        {
            vFXManager.makeSlowEffect(other.gameObject, spell);

            // check tag and if it is an enemy (or something that can move), decrease the speed and clamp it
        }

        if (getIdAttribute(3) == 4) // increase speed
        {
            
        }

        if (getIdAttribute(3) == 5) // heal
        {
            
        }

        if (getIdAttribute(3) == 6) // invisible
        {
            
        }
    }

    void checkElementType(VFXManager vFXManager)
    {
        if (getIdAttribute(0) == 1 || getIdAttribute(1) == 1)
        {
            Debug.Log("fire spell");
            // vFXManager.fireHit(gameObject);
        }
    }

    int getIdAttribute(int i)
    {
        return spellAction.getIdAttribute(i);
    }

}
