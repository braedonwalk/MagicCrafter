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
    Vector2 AOEPos;

    [SerializeField] ParticleSystem steamFX;
    float startSize = 0f;

    [SerializeField] GameObject spellPrefab;

    private void Start() {
        aimAtMouse = GetComponent<AimAtMouse>();
    }

    void Update()
    {
        mousePos = aimAtMouse.getMousePos();    //remove this eventually
        AOEPos = aimAtMouse.getAOEPos();

        if(!aimAtMouse.getIsProjectile()){
            if(Input.GetButtonDown("Fire1")){      //CHANGE KEY TYPE
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AOEPos, AOERange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().removeHealth(damage);
                }
                // Debug.Log("AOE");
                spellPrefab.transform.localScale = new Vector2(AOERange*2, AOERange*2);
                playSteamVFX(1);
                Instantiate(spellPrefab, AOEPos, this.transform.rotation);
            }
        }
    }

    void playSteamVFX(int numParticlesEmit){
        var main = steamFX.main;
        // main.startLifetime = steamFX + 0.2f;
        main.startSize = startSize + AOERange/2;
        Debug.Log(startSize + AOERange);
        steamFX.Emit(numParticlesEmit);
        // Destroy(spellPrefab, destroyDelay);
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
