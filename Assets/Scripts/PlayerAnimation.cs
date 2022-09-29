using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        float playerSpeed = this.GetComponent<PlayerStatManager>().getPlayerSpeed();
        Debug.Log(playerSpeed);

        animator.SetFloat("speed", playerSpeed);
    }
}
