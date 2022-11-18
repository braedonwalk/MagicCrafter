using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{

    [SerializeField] float defaultMoveSpeed = 5f;
    [SerializeField] float maxHealth = 5f;
    float moveSpeed;
    float defaultRed;
    float defaultGreen;
    float defaultBlue;

    private void Start() {
        moveSpeed = defaultMoveSpeed;
        defaultRed = this.GetComponent<SpriteRenderer>().color.r;
        defaultGreen = this.GetComponent<SpriteRenderer>().color.g;
        defaultBlue = this.GetComponent<SpriteRenderer>().color.b;
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

    public void setTintToDefault()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(defaultRed,defaultGreen,defaultBlue);
    }

    // health functions
    // public get
}
