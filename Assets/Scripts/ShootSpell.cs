using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpell : MonoBehaviour
{

    public Transform spellOrigin;
    public GameObject spellPrefab;
    // PlayerSoundManager soundManager;

    void Start()
    {
        
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
        Instantiate(spellPrefab, spellOrigin.position, spellOrigin.rotation);
    }
}
