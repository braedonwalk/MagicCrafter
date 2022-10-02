using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAOE : MonoBehaviour
{
    
    // [SerializeField] Transform attackPos;
    [SerializeField] LayerMask whatIsEnemies;
    [SerializeField] float attackRange = 1;
    AimAtMouse aimAtMouse;
    Vector2 mousePos;

    [SerializeField] GameObject spellPrefab;

    private void Start() {
        aimAtMouse = GetComponent<AimAtMouse>();
    }

    void Update()
    {
        mousePos = aimAtMouse.getMousePos();

        if(Input.GetButtonDown("Fire1")){      //CHANGE KEY TYPE
            Debug.Log("AOE");
            spellPrefab.transform.localScale = new Vector2(attackRange*2, attackRange*2);
            Instantiate(spellPrefab, mousePos, this.transform.rotation);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mousePos, attackRange);
    }
}
