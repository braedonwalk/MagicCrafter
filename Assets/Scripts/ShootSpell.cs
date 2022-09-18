using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpell : MonoBehaviour
{

    [SerializeField] Transform spellOrigin;
    [SerializeField] GameObject spellPrefab;
    // PlayerSoundManager soundManager;

    float spellForce = 5f; //MIGRATE TO SPELL MOVEMENT LATER

    void Start()
    {
        // soundManager = GetComponent<PlayerSoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Debug.Log("fire");
            cast();
        }
    }

    public void cast(){
        GameObject spell = Instantiate(spellPrefab, spellOrigin.position, spellOrigin.rotation);
        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        rb.AddForce(spellOrigin.up * spellForce, ForceMode2D.Impulse);
    }
}
