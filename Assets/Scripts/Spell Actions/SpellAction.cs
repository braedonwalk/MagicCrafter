using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAction : MonoBehaviour
{
    SpellInputManager spellInputManager;
    PlayerStatManager statManager;
    VFXManager vFXManager;
    [SerializeField] PauseGame pause;

    // int spellType;
    // float cooldown;
    // float damage;
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
    [SerializeField] ParticleSystem speedFX;
    float modifiedSpeed = 10f;
    float speedTime = 5f;

    float nextCastTime;
    // GameObject equippedSlot;
    // SpellCooldown SpellCooldown;

    void Start()
    {
        spellInputManager = GetComponentInParent<SpellInputManager>();
        statManager = GetComponentInParent<PlayerStatManager>();
        vFXManager = GetComponentInParent<VFXManager>();
    }

    void Update()
    {
        if(!pause.getIsPaused())
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // SpellCooldown = GetComponent<SpellCooldown>();

                // if (Time.time > nextCastTime)        //TURN ON COOLDOWN LATER
                // if (spellInputManager.getActiveSpellSlot().GetComponent<UICooldown>().getIsCooldown())
                // {
                    spellPrefab = getActiveSpell().prefab;
                    // Debug.Log("Casting: " + (getActiveSpell().name));
                    
                    if (getIdAttribute(2) == 1)
                    {
                        // PROJECTILE
                        castProjectile();
                    }
                    else if (getIdAttribute(2) == 2)
                    {
                        // AOE
                        castAOE();
                    }
                    else if (getIdAttribute(2) == 3)
                    {
                        // SELF
                        castSelf();
                    }

                    nextCastTime = Time.time + getActiveSpell().cooldown;
                // }
            }
        }
    }

    public Spell getActiveSpell(){
        return spellInputManager.getActiveSpell();
    }

    List<int> getListOfDigits()
    {
        List<int> listOfDigits = new List<int>();

        int id = getActiveSpell().id;

        while(id > 0)
        {
            listOfDigits.Add(id % 10);
            id /= 10;
        }
        listOfDigits.Reverse();

        return listOfDigits;
    }

    public int getIdAttribute(int i)
    {    
        return getListOfDigits()[i];
    }

    void castProjectile()
    {
        GameObject projectile = Instantiate(spellPrefab, this.transform.position, this.transform.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(this.transform.up * getActiveSpell().speed, ForceMode2D.Impulse);

        Destroy(projectile, getActiveSpell().duration);

    }

    void castAOE()
    {
        Vector2 AOEPos = GetComponent<Rigidbody2D>().position;
        AOEDiameter = getActiveSpell().diameter;

        // damage anyone in AOE diameter if damage should be applied
        if (getActiveSpell().damage != 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AOEPos, AOEDiameter, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyHealth>().removeHealth(getActiveSpell().damage);
            }
        }
        // Debug.Log("AOE");
        spellPrefab.transform.localScale = new Vector2(AOEDiameter-2, AOEDiameter-2);   //SCALING IS ALL WRONG
        // playSteamVFX(1);
        GameObject instantiatedObject = Instantiate(spellPrefab, AOEPos, this.transform.rotation);

        Destroy(instantiatedObject, getActiveSpell().duration);
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

    void castSelf()
    {
        Debug.Log(("casting self spell"));
        int effectId = getIdAttribute(3);
        
        if(effectId == 4)
        {
            Debug.Log("i am speed");
            statManager.changePlayerSpeed(modifiedSpeed);
            vFXManager.increasePlayerSpeed(getActiveSpell());
            
            Invoke("resetPlayerSpeed", getActiveSpell().duration);
        }
        else if(effectId == 1)
        {
            Debug.Log("he burn");
            vFXManager.spontaneousCombustion(getActiveSpell());
        }
        else if (effectId == 3)
        {
            Debug.Log("slowww");
            statManager.changePlayerSpeed(statManager.getPlayerSpeed()/2);
            vFXManager.decreasePlayerSpeed(getActiveSpell());

            Invoke("resetPlayerSpeed", getActiveSpell().duration);
            Invoke("resetPlayerTint", getActiveSpell().duration);

        }
    }

    void resetPlayerSpeed(){
        float defaultSpeed = statManager.getDefaultSpeed();
        statManager.changePlayerSpeed(defaultSpeed);
        Debug.Log("stop speed");
    }

    void resetPlayerTint()
    {
        statManager.setTintToDefault();
    }

    void playSpeedFX(int numParticlesEmit){
        var main = speedFX.main;
        main.startLifetime = speedTime + 0.2f;
        speedFX.Emit(numParticlesEmit);
    }

    public float getOriginDistance(){
        return spellInputManager.getActiveSpell().originDistance;;
    }
}
