using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("hit");
        Destroy(this.gameObject);
    }
}
