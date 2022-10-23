using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(!other.gameObject.CompareTag("Player")){
            // Debug.Log(other);
            Destroy(this.gameObject);

            //////////deal damgage/status effect/etc.
        }
        
    }
}
