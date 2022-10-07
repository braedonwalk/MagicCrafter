using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] int health = 3;
    [SerializeField] bool isDead = false;
    // EnemySoundManager soundManager;
    // EnemyParticleEffectManager particleEffectManager;

    private void Start() {
        // soundManager = GetComponent<EnemySoundManager>();
        // particleEffectManager = GetComponent<EnemyParticleEffectManager>();
    }

    private void Update() {
        destroyEnemy();
    }

    public void removeHealth(int damageTaken){
        health -= damageTaken;
        Debug.Log("Enemy Health: " + health);
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

    public int getHealth(){
        return health;
    }
}
