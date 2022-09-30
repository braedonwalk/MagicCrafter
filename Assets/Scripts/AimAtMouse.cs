using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Camera cam;
    Vector2 playerPosition;
    Rigidbody2D rigidBody;
    // Vector2 mousePos;
    // Vector3 towardMouse;
    float distance = 1f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerPosition = player.GetComponent<Rigidbody2D>().position;
        
        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        // towardMouse = (mousePos - playerPosition).normalized;

        // Debug.Log(towardMouse);
    }

    private void FixedUpdate() {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePos - rigidBody.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = angle;

        Vector3 towardMouse = (mousePos - playerPosition).normalized;
        rigidBody.position =  towardMouse * distance + player.transform.position;
    }
}
