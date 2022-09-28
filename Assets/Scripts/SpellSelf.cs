using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelf : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerStatManager statManager;
    [SerializeField] ParticleSystem speedFX;
    [SerializeField] float newSpeed = 10f;
    [SerializeField] float speedTime = 5f;

    void Start()
    {
        statManager = player.GetComponent<PlayerStatManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown("c")){      //CHANGE KEY TYPE
            // speedFX.Emit(1);
            Debug.Log("i am speed");
            statManager.changePlayerSpeed(newSpeed);
            playSpeedFX();
            
            Invoke("changePlayerSpeed", speedTime);
        }
    }

    void changePlayerSpeed(){
        float defaultSpeed = statManager.getDefaultSpeed();
        statManager.changePlayerSpeed(defaultSpeed);
        Debug.Log("stop speed");
    }

    void playSpeedFX(){
        var main = speedFX.main;
        main.startLifetime = speedTime + 0.2f;
        speedFX.Emit(1);
    }
}
