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
    int distance = 1;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerPosition = player.GetComponent<Rigidbody2D>().position;
        // rigidBody.MovePosition(rigidBody.position + testVector);
        // rigidBody.position = playerPosition;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        rigidBody.position = (transform.position - player.transform.position).normalized * distance + player.transform.position;

        //THIS IS CLOSER TO WHAT I WANT
        // Vector3 towardMouse = (transform.position - Input.mousePosition).normalized;

        // rigidBody.position =  towardMouse * distance + player.transform.position;
    }

    private void FixedUpdate() {
        Vector2 aimDirection = mousePos - rigidBody.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = angle;
    }
}
