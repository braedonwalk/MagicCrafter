using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{

    [SerializeField] float defaultMoveSpeed = 5f;
    float moveSpeed;

    private void Start() {
        moveSpeed = defaultMoveSpeed;
    }

    public float getDefaultSpeed(){
        return defaultMoveSpeed;
    }
    public float getPlayerSpeed(){
        return moveSpeed;
    }

    public void changePlayerSpeed(float x){
        moveSpeed = x;
    }
}
