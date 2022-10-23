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

    [SerializeField] float originDistance;

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
        
    }

    float getOriginDistance(){
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
