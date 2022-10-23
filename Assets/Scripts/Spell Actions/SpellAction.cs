using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAction : MonoBehaviour
{
    SpellInputManager spellInputManager;
    PlayerStatManager statManager;
    [SerializeField] PauseGame pause;

    int spellType;
    float cooldown;
    float damage;
    GameObject spellPrefab;

    float originDistance;

    // Projectile
    float projectileRange;
    // float projectileSpeed;

    // AOE
    float AOEDiameter;
    AimAtMouse aimAtMouse;
    Vector2 AOEPos;
    [SerializeField] LayerMask whatIsEnemies;

    // Self
    float effectDuration;

    void Start()
    {
        spellInputManager = GetComponentInParent<SpellInputManager>();
        statManager = GetComponentInParent<PlayerStatManager>();
    }

    void Update()
    {
        if(!pause.getIsPaused())
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (getSpellType() == 1)
                {
                    // PROJECTILE
                    string activeSpellName = getActiveSpell().spellName;
                    spellPrefab = getActiveSpell().prefab;
                    float projectileSpeed = getActiveSpell().speed;

                    castProjectile(spellPrefab, projectileSpeed);
                    // Debug.Log(activeSpellName);
                }
                else if (getSpellType() == 2)
                {
                    //AOE
                }
                else if (getSpellType() == 3)
                {
                    // SELF
                }
            }
        }
    }

    Spell getActiveSpell(){
        return spellInputManager.getActiveSpell();
    }

    int getSpellType(){
        return spellInputManager.getActiveSpell().spellType;
    }

    void castProjectile(GameObject prefab, float speed)
    {
        GameObject spell = Instantiate(prefab, this.transform.position, this.transform.rotation);
        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        rb.AddForce(this.transform.up * speed, ForceMode2D.Impulse);
    }

    float getOriginDistance(){
        if (spellType == 1){
            return 1f;
        }
        else if (spellType == 2){
            return 2f;
        }
        else {
            return 0f;
        }
    }
}
