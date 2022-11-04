using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSpriteRotation : MonoBehaviour
{
    // [SerializeField] Sprite sprite;
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        spriteRenderer.transform.rotation = Quaternion.identity;
    }
}
