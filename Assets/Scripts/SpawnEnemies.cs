using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject obj in enemyList)
            {
                Destroy(obj);
            }
            Debug.Log("hey");
            Instantiate(prefab, this.transform);
        }
    }
}
