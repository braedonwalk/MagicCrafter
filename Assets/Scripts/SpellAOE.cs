using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAOE : MonoBehaviour
{
    
    // [SerializeField] Transform attackPos;
    [SerializeField] LayerMask whatIsEnemies;
    [SerializeField] float AOERange = 1;
    [SerializeField] int damage = 1;
    [SerializeField] float AOEOriginDistance = 2f;
    AimAtMouse aimAtMouse;
    Vector2 mousePos;

    [SerializeField] GameObject spellPrefab;

    private void Start() {
        aimAtMouse = GetComponent<AimAtMouse>();
    }

    void Update()
    {
        mousePos = aimAtMouse.getMousePos();

        if(!aimAtMouse.getIsProjectile()){
            if(Input.GetButtonDown("Fire1")){      //CHANGE KEY TYPE
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(mousePos, AOERange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().removeHealth(damage);
                }
                // Debug.Log("AOE");
                spellPrefab.transform.localScale = new Vector2(AOERange*2, AOERange*2);
                Instantiate(spellPrefab, mousePos, this.transform.rotation);
            }
        }
    }

    public float getAOEOriginDistance(){
        return AOEOriginDistance;
    }

    //EVENTUALLY GET RID OF THIS
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mousePos, AOERange);
    }
}
