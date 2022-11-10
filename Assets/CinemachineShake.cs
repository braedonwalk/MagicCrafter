using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{

CinemachineVirtualCamera vc;

float shakeTimer = 0;
float maxIntensityOfActiveShake = 0f;
float maxDurationOfActiveShake = 0f;

private void Awake() 
{
    vc = this.GetComponent<CinemachineVirtualCamera>();
}

private void Update() 
{
    if (shakeTimer > 0)
    {
        // get intensity mapped from time left
        float newIntensity = maxIntensityOfActiveShake * Mathf.Lerp(0.0f, maxDurationOfActiveShake, shakeTimer);
        // update intensity of shae
        vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = newIntensity;

        shakeTimer -= Time.deltaTime;
        Debug.Log(newIntensity);
    }
}

public void startCameraShake(float newIntensity, float duration)
{
    // Start a new shake to last the max duration and set the max intensity/duration of this shake
    shakeTimer = duration;
    maxIntensityOfActiveShake = newIntensity;
    maxDurationOfActiveShake = duration;
    vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = newIntensity;
    

    
    
}


}
