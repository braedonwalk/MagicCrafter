using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAction : MonoBehaviour
{
    SpellInputManager spellInputManager;
    PlayerStatManager statManager;
    VFXManager vFXManager;
    SpellSoundManager soundManager;
    [SerializeField] PauseGame pause;
    [SerializeField] CinemachineShake cinemachineShake;

    // int spellType;
    // float cooldown;
    // float damage;
    GameObject spellPrefab;

    float originDistance;

    // Projectile
    float projectileRange;
    // float projectileSpeed;

    // AOE
    float AOERadius;
    // [SerializeField] ParticleSystem steamFX;
    // AimAtMouse aimAtMouse;
    // Vector2 AOEPos;
    [SerializeField] LayerMask whatIsEnemies;

    // Self
    float effectDuration;
    [SerializeField] ParticleSystem speedFX;
    float speedIncrease = 10f;
    // float speedDecrease = 2f;
    // float speedTime = 5f;

    float nextCastTime;
    // GameObject equippedSlot;
    // SpellCooldown SpellCooldown;

    void Start()
    {
        spellInputManager = GetComponentInParent<SpellInputManager>();
        statManager = GetComponentInParent<PlayerStatManager>();
        vFXManager = GetComponentInParent<VFXManager>();
        soundManager = GetComponentInParent<SpellSoundManager>();
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
                    Debug.Log("Cast: " + getActiveSpell().name);

                    nextCastTime = Time.time + getActiveSpell().cooldown;

                    soundManager.checkSpellCast();
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
        Vector2 AOEPos = GetComponent<Rigidbody2D>().position; //cursor position
        AOERadius = getActiveSpell().diameter/2; // diameter attribute of spell

        int effect1Id = getIdAttribute(3);
        int effect2Id = getIdAttribute(4);

        // damage anyone in AOE diameter if damage should be applied
        if (getActiveSpell().damage != 0)
        {            
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AOEPos, AOERadius, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyHealth>().removeHealth(getActiveSpell().damage);

                if (effect1Id == 3 || effect2Id == 3)
                {
                    vFXManager.makeSlowEffect(enemiesToDamage[i].gameObject, getActiveSpell());
                    Debug.Log("red" + enemiesToDamage[i].GetComponent<SpriteRenderer>().color.r);
                    Debug.Log("green" + enemiesToDamage[i].GetComponent<SpriteRenderer>().color.g);
                    Debug.Log("blue" + enemiesToDamage[i].GetComponent<SpriteRenderer>().color.b);
                }

            }
        }

        spellPrefab.transform.localScale = new Vector2(AOERadius*2, AOERadius*2);
        GameObject instantiatedObject = Instantiate(spellPrefab, AOEPos, this.transform.rotation);

        Destroy(instantiatedObject, getActiveSpell().duration);

        // special cases
        if (getActiveSpell().id == 3323) //EES- Earthquake
        {
            cinemachineShake.startCameraShake(10, 3);
        }
        // TODO: Refactor this by checking some effectId numbers and applying the proper one.
        if (getActiveSpell().id == 23130) // WE AOE- mud splash
        {

        }
    }

    private void OnDrawGizmosSelected() {
        // Vector2 mousePos = GetComponent<AimAtMouse>().getMousePos();
        Vector2 mousePos = GetComponent<Rigidbody2D>().position;
        AOERadius = getActiveSpell().diameter/2;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mousePos, AOERadius);
    }


    // TODO: Refactor this so that all unique spells are checked first and then
    // all subsequent if statements check to see if effect1Id == # || effect2Id == #
    // no else if's there so that multiple effects could be applied.
    void castSelf()
    {
        Debug.Log(("casting self spell"));
        int effect1Id = getIdAttribute(3);
        int effect2Id = getIdAttribute(4);
        
        // unique spells
        // TODO: make it where the parameters for startHealthChangeOverTime refer to spell attributes
        if (getActiveSpell().id == 23350) // waterEarthSelf- slow heal
        {
            Debug.Log("healing over time");
            statManager.startHealthChangeOverTime(statManager.getHealth() + 1.0f, 0.001f, 5f);
        }

        // if there is only one effect
        else if (effect2Id == 0)
        {
            if(effect1Id == 4)
            {
                Debug.Log("i am speed");
                statManager.changePlayerSpeed(speedIncrease);
                vFXManager.increasePlayerSpeed(getActiveSpell());
                
                Invoke("defaultPlayerSpeed", getActiveSpell().duration);
            }
            else if(effect1Id == 1)
            {
                Debug.Log("he burn");
                vFXManager.spontaneousCombustion(getActiveSpell());
            }
            else if (effect1Id == 3)
            {
                Debug.Log("slowww");
                statManager.changePlayerSpeed(statManager.getPlayerSpeed()/2);
                vFXManager.decreasePlayerSpeed(getActiveSpell());

                Invoke("defaultPlayerSpeed", getActiveSpell().duration);
                Invoke("resetPlayerTint", getActiveSpell().duration);
            }
        
            else if(effect1Id == 6)
            {
                Debug.Log("his name is John Cena");
                float newVisibility = 0.6f;
                SpriteRenderer sprite = GetComponentInParent<SpriteRenderer>();
                sprite.color = new Color (1, 1, 1, newVisibility);
                // Debug.Log(sprite.color);
                Invoke("defaultVisibility", getActiveSpell().duration);

            }

            else if (effect1Id == 5)
            {
                Debug.Log("healing");
                statManager.setHealth(statManager.getHealth() + 1.0f);

                GameObject effect = Instantiate(spellPrefab, this.transform.position, this.transform.rotation);

                Destroy(effect, getActiveSpell().duration);
            }
        }

        // if there are two effects
        else
        {
            // burn and increase speed
            if ( (effect1Id == 1 && effect2Id == 4) || (effect1Id == 4 && effect2Id == 1) )
            {
                Debug.Log("he burn and zoom");
                vFXManager.spontaneousCombustion(getActiveSpell());
                statManager.changePlayerSpeed(speedIncrease);
                statManager.startHealthChangeOverTime(statManager.getHealth() + 1.0f, -0.001f, 5f);

                Invoke("defaultPlayerSpeed", getActiveSpell().duration);
            }
        }
    }
    
    void defaultPlayerSpeed(){
        float defaultSpeed = statManager.getDefaultSpeed();
        statManager.changePlayerSpeed(defaultSpeed);
        Debug.Log("default speed");
    }

    void resetPlayerTint()
    {
        statManager.setTintToDefault();
    }

    void defaultVisibility()
    {
        float defaultVisibility = 1;
        SpriteRenderer sprite = GetComponentInParent<SpriteRenderer>();
        // Color spriteRendererA = GetComponentInParent<SpriteRenderer>().color;
        sprite.color = new Color(1, 1, 1, defaultVisibility);
        Debug.Log("visible");
    }

    // void playSpeedFX(int numParticlesEmit){
    //     var main = speedFX.main;
    //     main.startLifetime = speedTime + 0.2f;
    //     speedFX.Emit(numParticlesEmit);
    // }

    public float getOriginDistance(){
        return spellInputManager.getActiveSpell().originDistance;;
    }
}
