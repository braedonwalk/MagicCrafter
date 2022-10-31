using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    
    [SerializeField] Spell spell;
    
    private void OnCollisionEnter2D(Collision2D other) {

        VFXManager vFXManager = other.gameObject.GetComponent<VFXManager>();


        if(!other.gameObject.CompareTag("Player")){
            // Debug.Log(other);
            Destroy(this.gameObject);

            //////////deal damgage/status effect/etc.
        }

        if (other.gameObject.tag == "Object")
        {            
            
            if (getEffect() == 1) // burning
            {
                vFXManager.makeBurnEffect(other.gameObject, spell);
            }
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
