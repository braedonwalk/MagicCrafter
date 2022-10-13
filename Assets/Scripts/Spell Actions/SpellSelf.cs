using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelf : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerStatManager statManager;
    [SerializeField] ParticleSystem speedFX;
    [SerializeField] float modifiedSpeed = 10f;
    [SerializeField] float speedTime = 5f;

    [SerializeField] PauseGame pause;

    void Start()
    {
        statManager = player.GetComponent<PlayerStatManager>();
    }

    void Update()
    {
        if(!pause.getIsPaused())
        {
            if(Input.GetButtonDown("Fire2"))     //CHANGE KEY TYPE
            { 
                // speedFX.Emit(1);
                Debug.Log("i am speed");
                statManager.changePlayerSpeed(modifiedSpeed);
                playSpeedFX(1);
                
                Invoke("changePlayerSpeed", speedTime);
            }
        }
    }

    void changePlayerSpeed(){
        float defaultSpeed = statManager.getDefaultSpeed();
        statManager.changePlayerSpeed(defaultSpeed);
        Debug.Log("stop speed");
    }

    void playSpeedFX(int numParticlesEmit){
        var main = speedFX.main;
        main.startLifetime = speedTime + 0.2f;
        speedFX.Emit(numParticlesEmit);
    }
}
