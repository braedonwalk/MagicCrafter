using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] float health = 20f;
    [SerializeField] bool isDead = false;
    [SerializeField] Image healthBarImage;
    // EnemySoundManager soundManager;
    // EnemyParticleEffectManager particleEffectManager;

    float maxHealth;

    private void Start() {
        // soundManager = GetComponent<EnemySoundManager>();
        // particleEffectManager = GetComponent<EnemyParticleEffectManager>();
        maxHealth = health;
    }

    private void Update() {
        destroyEnemy();
    }

    public void removeHealth(float damageTaken){
        health -= damageTaken;
        healthBarImage.fillAmount = health/maxHealth;

    }

    void destroyEnemy(){
        if(health <= 0){
            if(!isDead){
                // soundManager.playDeathSound();
                // particleEffectManager.playDeathFX();
                Destroy(this.gameObject, 0.2f);
                isDead = true;
            }
        }
    }

    public float getHealth(){
        return health;
    }
}
