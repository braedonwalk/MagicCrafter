using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Camera cam;
    SpellAction spellAction;
    Vector2 playerRbPosition;
    Vector3 playerTransformPosition;
    Rigidbody2D rigidBody;
    Vector2 mousePos;
    Vector3 towardMouse;
    [SerializeField] bool isProjectile = true;

    void Start()
    {
        spellAction = GetComponent<SpellAction>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerRbPosition = player.GetComponent<Rigidbody2D>().position;
        playerTransformPosition = player.GetComponent<Transform>().position;
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate() {

        int modifierId = spellAction.getIdAttribute(2);

        if (modifierId == 1)
        {
            setAngle();
            setTowardMouse(1);
            setOriginPosition();
        }
        else if (modifierId == 2)
        {
            rigidBody.rotation = 0;
            setTowardMouse(2);
            checkWithinRange();
        }
        else 
        {
            setOriginPosition();
            rigidBody.rotation = 0;
        }
    }

    void setAngle()
    {
        Vector2 aimDirection = mousePos - rigidBody.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = angle;
    }

    void setTowardMouse(int type)
    {
        if (type == 1){
            towardMouse = (mousePos - playerRbPosition).normalized;
        }
        else if (type == 2){
            towardMouse = mousePos - playerRbPosition;
        }
    }

    void checkWithinRange()
    {
        if (Vector3.Distance(mousePos, playerTransformPosition) <= spellAction.getOriginDistance())
        {
            rigidBody.position = towardMouse + playerTransformPosition;
        }
        else
        {
            setTowardMouse(1);
            setOriginPosition();
        }
    }

    void setOriginPosition()
    {   
       rigidBody.position = towardMouse * spellAction.getOriginDistance() + playerTransformPosition; // maybe here is the problem??
    }

    public Vector2 getMousePos(){
        return mousePos;
    }

    public bool getIsProjectile(){
        return isProjectile;
    }

    public Vector2 getAOEPos(){
        return rigidBody.position;
    }
}
