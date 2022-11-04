using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField] Spell spell;

    void Start()
    {
        Destroy(this.gameObject, spell.duration);
    }

}
