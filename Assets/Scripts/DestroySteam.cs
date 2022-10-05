using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySteam : MonoBehaviour
{

    float destroyDelay = 1f;
    void Start()
    {
        Destroy(this.gameObject, destroyDelay);
    }

}
