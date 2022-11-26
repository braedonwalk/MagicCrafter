using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{

    [SerializeField] float defaultMoveSpeed = 5f;
    [SerializeField] float maxHealth = 5f;
    [SerializeField] Image healthBarImage;
    float moveSpeed;
    float defaultRed;
    float defaultGreen;
    float defaultBlue;

    [SerializeField] float currentHealth;
    bool healthIsChanging;
    float healthGoal;
    float durationOfHealthChange;
    float amtOfHealthChange;
    float startTime;


    bool isArmored;

    private void Start() {
        moveSpeed = defaultMoveSpeed;
        defaultRed = this.GetComponent<SpriteRenderer>().color.r;
        defaultGreen = this.GetComponent<SpriteRenderer>().color.g;
        defaultBlue = this.GetComponent<SpriteRenderer>().color.b;

        currentHealth = maxHealth;
        healthIsChanging = false;
        startTime = 0;

        isArmored = false;
    }

    private void Update() 
    {
        // changeHealthOverTime();
        healthBarImage.fillAmount = currentHealth/maxHealth;
    }

    // speed functions
    public float getDefaultSpeed(){
        return defaultMoveSpeed;
    }
    public float getPlayerSpeed(){
        return moveSpeed;
    }

    public void changePlayerSpeed(float x){
        moveSpeed = x;
    }

    // tint functions
    public void setTintToDefault()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(defaultRed,defaultGreen,defaultBlue);
    }

    // health functions
    public float getHealth()
    {
        return currentHealth;
    }

    // TODO: refactor this
    public void setHealth(float newHealth)
    {
        // if losing health
        if (newHealth < currentHealth && isArmored == false)
        {
            currentHealth = newHealth;
        }

        // if gaining health
        else if (newHealth > currentHealth)
        {
            currentHealth = newHealth;
        }
    }

    public void startHealthChangeOverTime(float newHealthGoal, float newAmtOfHealthChange, float newDurationOfHealthChange)
    {
        healthGoal = newHealthGoal;
        amtOfHealthChange = newAmtOfHealthChange;

        StartCoroutine(Countdown());
    }

     private IEnumerator Countdown()
    {
        float duration = 3f; // 3 seconds you can change this 
        //to whatever you want
        float normalizedTime = 0;

        while(normalizedTime <= duration)
        {
            normalizedTime += Time.deltaTime / duration;
            
            currentHealth += amtOfHealthChange;

            currentHealth = Mathf.Clamp(currentHealth, 0 , maxHealth);

            yield return null;
        }
    }
    
    // TODO: Probablu remove this
    // void changeHealthOverTime()
    // {        
    //     if (!healthIsChanging)
    //     {
    //         startTime = Time.fixedDeltaTime; 
    //     }

    //     else
    //     {
    //         Debug.Log("health: " + currentHealth);
    //         // Debug.Log("time passed: " + (Time.deltaTime - startTime));
    //         // Debug.Log("duration: " + durationOfHealthChange);
            
    //         // if the timer is still active
    //         // if (Time.deltaTime - startTime > durationOfHealthChange)
    //         // {
    //             // if health should increase
    //             if (currentHealth < healthGoal)
    //             {
    //                 currentHealth += amtOfHealthChange;

    //                 if (currentHealth >= healthGoal)
    //                 {
    //                     healthIsChanging = false;
    //                 }
    //             }
    //             // if health should decrease
    //             else 
    //             {
    //                 currentHealth -= amtOfHealthChange;
                    
    //                 if (currentHealth <= healthGoal)
    //                 {
    //                     healthIsChanging = false;
    //                 }
    //             }
    //         // }
    //         // if timer has triggered
    //         // else 
    //         // {
    //         //     healthIsChanging = false;

    //         // }
    //     }
    // }

    // armor function
    public void setArmor(bool isNowArmored)
    {
        isArmored = isNowArmored;
    }

    public bool getIsArmored()
    {
        return isArmored;
    }
}
