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
    GameObject prefab;

    float originDistance;

    // Projectile
    float projectileRange;
    float projectileSpeed;

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
                    string activeSpellName = spellInputManager.getActiveSpell().spellName;

                    if(activeSpellName == "FireProjectile")
                    {
                        Debug.Log("fire projectile");
                        // cast(fireBoltPrefab);
                    }
                    else if(activeSpellName == "EarthProjectile")
                    {
                        Debug.Log("rock projectile");
                        // cast(rockBoltPrefab);
                    }
                    else if(activeSpellName == "WaterProjectile")
                    {
                        Debug.Log("water projectile");
                        // cast(rockBoltPrefab);
                    }
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

    int getSpellType()
    {
        return spellInputManager.getActiveSpell().spellType;
    }

    float getOriginDistance()
    {
        if (spellType == 1)
        {
            return 1f;
        }
        else if (spellType == 2)
        {
            return 2f;
        }
        else 
        {
            return 0f;
        }
    }
}
