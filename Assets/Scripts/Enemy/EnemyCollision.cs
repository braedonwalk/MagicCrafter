using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    
    [SerializeField] float damageOnCollision = 1f;
    

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("collide with enemy");
            // subtract player health
            other.gameObject.GetComponent<PlayerStatManager>().setHealth(other.gameObject.GetComponent<PlayerStatManager>().getHealth() - damageOnCollision);

            // push player away
            Vector2 pushVector = other.gameObject.transform.position - this.transform.position;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushVector.normalized * 1500);
        }
    }
}
