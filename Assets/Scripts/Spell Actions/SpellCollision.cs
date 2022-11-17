using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    
    [SerializeField] Spell spell;
    EnemyHealth enemyHealth;

    private void OnCollisionEnter2D(Collision2D other) {

        VFXManager vFXManager = other.gameObject.GetComponent<VFXManager>();
        


        if(!other.gameObject.CompareTag("Player"))
        {
            // Debug.Log(other);
            Destroy(this.gameObject);

            //////////deal damgage/status effect/etc.
        }
        else
        {
            Destroy(this.gameObject);
            // can instantiate effect or play sound here
        }

        if (other.gameObject.tag == "Object")
        {            
            int effect1 = getEffects().Item1;
            int effect2 = getEffects().Item1;
            
            if (effect1 == 1 || effect2 == 1) // burning
            {
                vFXManager.makeBurnEffect(other.gameObject, spell);
                Debug.Log("burnnnnnnn");
            }

            if (effect1 == 2 || effect2 == 2) // wet
            {
                
            }

            if (effect1 == 3 || effect2 == 3) // slow
            {
               vFXManager.makeSlowEffect(other.gameObject, spell);

               // check tag and if it is an enemy (or something that can move), decrease the speed and clamp it
            }

            if (effect1 == 4 || effect2 == 4) // increase speed
            {
               
            }

            if (effect1 == 5 || effect2 == 5) // heal
            {
                
            }

            if (effect1 == 6 || effect2 == 6) // invisible
            {
               
            }
        }

        if (other.gameObject.tag == "Enemy")
        {
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.removeHealth(spell.damage);
        }
        
    }

    (int, int) getEffects()
    {
        List<int> listOfDigits = new List<int>();

        int id = spell.id;

        while(id > 0)
        {
            listOfDigits.Add(id % 10);
            id /= 10;
        }
        listOfDigits.Reverse();
        
        return (listOfDigits[3], listOfDigits[4]);
    }


}
