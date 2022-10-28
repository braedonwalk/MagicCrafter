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
            vFXManager.makeBurnEffect(other.gameObject, spell);
        }
        
    }




}
