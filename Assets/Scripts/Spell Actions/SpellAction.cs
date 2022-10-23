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
    // [SerializeField] ParticleSystem steamFX;
    // AimAtMouse aimAtMouse;
    // Vector2 AOEPos;
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
                spellPrefab = getActiveSpell().prefab;
                if (getSpellType() == 1)
                {
                    // PROJECTILE
                    // string activeSpellName = getActiveSpell().spellName;
                    float projectileSpeed = getActiveSpell().speed;

                    castProjectile(spellPrefab, projectileSpeed);
                    // Debug.Log(activeSpellName);
                }
                else if (getSpellType() == 2)
                {
                    //AOE
                    castAOE();
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

    public int getSpellType(){
        return spellInputManager.getActiveSpell().spellType;
    }

    void castProjectile(GameObject prefab, float speed)
    {
        GameObject projectile = Instantiate(prefab, this.transform.position, this.transform.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(this.transform.up * speed, ForceMode2D.Impulse);
    }

    void castAOE()
    {
        Vector2 AOEPos = GetComponent<Rigidbody2D>().position;
        AOEDiameter = getActiveSpell().diameter;

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AOEPos, AOEDiameter, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyHealth>().removeHealth(getActiveSpell().damage);
        }
        // Debug.Log("AOE");
        spellPrefab.transform.localScale = new Vector2(AOEDiameter-2, AOEDiameter-2);   //SCALING IS ALL WRONG
        // playSteamVFX(1);
        Instantiate(spellPrefab, AOEPos, this.transform.rotation);
    }

    // void playSteamVFX(int numParticlesEmit){
    //     float startSize = 1;
    //     var main = steamFX.main;
    //     // main.startLifetime = steamFX + 0.2f;
    //     main.startSize = startSize + AOEDiameter/2;
    //     Debug.Log(startSize + AOEDiameter);
    //     steamFX.Emit(numParticlesEmit);
    //     // Destroy(spellPrefab, destroyDelay);
    // }

    public float getOriginDistance(){
        return spellInputManager.getActiveSpell().originDistance;;
    }
}
