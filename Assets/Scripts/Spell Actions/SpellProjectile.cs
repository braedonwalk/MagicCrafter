using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    
    [SerializeField] GameObject fireBoltPrefab;
    [SerializeField] GameObject rockBoltPrefab;
    // PlayerSoundManager soundManager;

    // float spellForce = 5f; //MIGRATE TO SPELL MOVEMENT LATER
    ProjectileMovement spellMovement;

    private void Start() {
        spellMovement = GetComponent<ProjectileMovement>();
    }

    void Update()
    {
        if(Input.GetKeyDown("f")){      //CHANGE KEY TYPE
            Debug.Log("fire");
            cast(fireBoltPrefab);
        }
        else if(Input.GetKeyDown("r")){ //CHANGE KEY TYPE
            Debug.Log("rock");
            cast(rockBoltPrefab);
        }

    }

    void cast(GameObject spellPrefab){
        GameObject spell = Instantiate(spellPrefab, this.transform.position, this.transform.rotation);
        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        rb.AddForce(this.transform.up * spellMovement.getSpellForce(), ForceMode2D.Impulse);
    }
}