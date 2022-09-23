using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpell : MonoBehaviour
{

    [SerializeField] Transform spellOrigin;
    [SerializeField] GameObject fireBoltPrefab;
    [SerializeField] GameObject rockBoltPrefab;
    // PlayerSoundManager soundManager;

    float spellForce = 5f; //MIGRATE TO SPELL MOVEMENT LATER

    void Start()
    {
        // soundManager = GetComponent<PlayerSoundManager>();
    }

    // Update is called once per frame
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

    public void cast(GameObject spellPrefab){
        GameObject spell = Instantiate(spellPrefab, spellOrigin.position, spellOrigin.rotation);
        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        rb.AddForce(spellOrigin.up * spellForce, ForceMode2D.Impulse);
    }
}
