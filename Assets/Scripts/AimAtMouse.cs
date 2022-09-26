using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Camera cam;
    Vector2 playerPosition;
    Rigidbody2D rigidBody;
    Vector2 mousePos;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerPosition = player.GetComponent<Rigidbody2D>().position;
        rigidBody.position = playerPosition;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        // Debug.Log(playerPosition);
    }

    private void FixedUpdate() {
        Vector2 aimDirection = mousePos - rigidBody.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = angle;
    }
}
