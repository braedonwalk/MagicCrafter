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

        if (other.gameObject.tag == "Object")
        {            
            
            
            if (getEffect() == 1) // burning
            {
                vFXManager.makeBurnEffect(other.gameObject, spell);
                Debug.Log("burnnnnnnn");
            }

            if (getEffect() == 2) // wet
            {
                
            }

            if (getEffect() == 3) // slow
            {
               vFXManager.makeSlowEffect(other.gameObject, spell);

               // check tag and if it is an enemy (or something that can move), decrease the speed and clamp it
            }

            if (getEffect() == 4) // increase speed
            {
               
            }

            if (getEffect() == 5) // heal
            {
                
            }

            if (getEffect() == 6) // invisible
            {
               
            }
        }

        if (other.gameObject.tag == "Enemy")
        {
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.removeHealth(spell.damage);
        }
        
    }

    int getEffect()
    {
        List<int> listOfDigits = new List<int>();

        int id = spell.id;

        while(id > 0)
        {
            listOfDigits.Add(id % 10);
            id /= 10;
        }
        listOfDigits.Reverse();
        
        return listOfDigits[3];
    }


}
