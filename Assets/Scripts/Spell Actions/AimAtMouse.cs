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
    // Vector3 towardMouse;
    // [SerializeField] float projectileOriginDistance = 1f;
    // [SerializeField] float AOEOriginDistance = 2f;
    SpellAOE spellAOE;
    SpellProjectile spellProjectile;
    [SerializeField] bool isProjectile = true;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spellAOE = GetComponent<SpellAOE>();
        spellProjectile = GetComponent<SpellProjectile>();
    }

    void Update()
    {
        playerPosition = player.GetComponent<Rigidbody2D>().position;
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        // towardMouse = (mousePos - playerPosition).normalized;

        // Debug.Log(towardMouse);
    }

    private void FixedUpdate() {
        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (isProjectile){
            Vector2 aimDirection = mousePos - rigidBody.position;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rigidBody.rotation = angle;

            Vector3 towardMouse = (mousePos - playerPosition).normalized;
            rigidBody.position = towardMouse * spellProjectile.getProjectileOriginDistance() + player.transform.position;
        }else{
            rigidBody.rotation = 0;
            Vector3 towardMouse = (mousePos - playerPosition);
            // Debug.Log(towardMouse);
            if (Vector3.Distance(towardMouse, player.transform.position) <= spellAOE.getAOEOriginDistance()){
                rigidBody.position = towardMouse + player.transform.position;
            }
            else{
                towardMouse = (mousePos - playerPosition).normalized;
                rigidBody.position = towardMouse * spellAOE.getAOEOriginDistance() + player.transform.position;
            }
        }
        
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
