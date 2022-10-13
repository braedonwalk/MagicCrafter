using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPickup : MonoBehaviour
{

    bool isPickUp = false;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("pickup");
            isPickUp = true;
        }
    }

    public bool getPickUp()
    {
        return isPickUp;
    }
}
