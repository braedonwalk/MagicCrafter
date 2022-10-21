using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rigidBody;

    Vector2 movement;
    PlayerStatManager player;
    Animator animator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerStatManager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("VerticalSpeed", movement.y);
        // Debug.Log(movement.y);
    }

    private void FixedUpdate() {
        rigidBody.MovePosition(rigidBody.position + movement * player.getPlayerSpeed() * Time.fixedDeltaTime);
    }

    
}
