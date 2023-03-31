using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/HealthBehaviour", fileName = "AcHealthBehaviour")]
public class HealthBehaviour : Action
{
    private float damageAcumulation;
    private float damageAcumulationCount;
    private float healthAcumulation;
    private float healthAcumulationCount;

    [SerializeField]
    private int maxBattery;

    [Tooltip("Duracion de recarga con potis")]
    [SerializeField]
    private float healDuration;
    [Tooltip("Duracion de recarga de bateria")]
    [SerializeField]
    private float rechargeDuration;

    [Tooltip("Duracion de la substraccion de bateria")]
    [SerializeField]
    private float substractVelocity;
    [Tooltip("Duracion de la autosubstraccion de bateria")]
    [SerializeField]
    private float autoSubstractVelocity;

    /*[SerializeField]
    private bool curation;*/

    [Header("La bateria se consume sola")]
    [SerializeField]
    private bool autoConsum;

    private PlayerController playerController;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;

        playerController.battery = maxBattery;
        playerController.SetAutoCuration(false);
    }

    public override void Act(Controller controller)
    {
        //Variables
        if (playerController.GetAutoCuration())
        {
            playerController.battery += Time.fixedDeltaTime * (maxBattery / rechargeDuration);
        }
        else if(autoConsum)
        {
            playerController.battery -= Time.fixedDeltaTime * (maxBattery / autoSubstractVelocity);
        }


        if(damageAcumulationCount > 0)
        {
            playerController.battery -= damageAcumulation / damageAcumulationCount;
            damageAcumulation -= damageAcumulation / damageAcumulationCount;
            damageAcumulationCount--;
        }

        if (healthAcumulationCount > 0)
        {
            playerController.battery += healthAcumulation / healthAcumulationCount;
            healthAcumulation -= healthAcumulation / healthAcumulationCount;
            healthAcumulationCount--;
        }

        //Limites
        if (playerController.battery <= 0)
        {
            playerController.battery = 0;
            damageAcumulation = 0;
            damageAcumulationCount = 0;
        }
        else if(playerController.battery >= maxBattery)
        {
            playerController.battery = maxBattery;
            healthAcumulation = 0;
            healthAcumulationCount = 0;
        }

        playerController.rende.material.SetFloat("_Health", playerController.battery / maxBattery);
    }


    /*public void SubstractHealth(int substract)
    {
        damageAcumulation += substract;
        damageAcumulationCount += substractVelocity;
    }
    
    public void AddtHealth(int healthAdded)
    {
        healthAcumulation += healthAdded;
        healthAcumulationCount += healthAdded * healDuration;
    }

    public void SetAutoCuration(bool setCuration)
    {
        curation = setCuration;
    }*/
}
