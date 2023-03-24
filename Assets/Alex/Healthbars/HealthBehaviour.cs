using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    private float damageAcumulation;
    private float damageAcumulationCount;
    private float healthAcumulation;
    private float healthAcumulationCount;

    public Renderer rende;
    [SerializeField]
    private int maxBattery;
    public float battery;

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

    [SerializeField]
    private bool curation;

    [Header("La bateria se consume sola")]
    [SerializeField]
    private bool autoConsum;


    // Start is called before the first frame update
    void Start()
    {
        battery = maxBattery;
        curation = false;
    }

    void FixedUpdate()
    {
        //Variables
        if(curation)
        {
            battery += Time.fixedDeltaTime * (maxBattery / rechargeDuration);
        }
        else if(autoConsum)
        {
            battery -= Time.fixedDeltaTime * (maxBattery / autoSubstractVelocity);
        }


        if(damageAcumulationCount > 0)
        {
            battery -= damageAcumulation / damageAcumulationCount;
            damageAcumulation -= damageAcumulation / damageAcumulationCount;
            damageAcumulationCount--;
        }

        if (healthAcumulationCount > 0)
        {
            battery += healthAcumulation / healthAcumulationCount;
            healthAcumulation -= healthAcumulation / healthAcumulationCount;
            healthAcumulationCount--;
        }

        //Limites
        if (battery <= 0)
        {
            battery = 0;
            damageAcumulation = 0;
            damageAcumulationCount = 0;
        }
        else if(battery >= maxBattery)
        {
            battery = maxBattery;
            healthAcumulation = 0;
            healthAcumulationCount = 0;
        }
        
        rende.material.SetFloat("_Health", battery / maxBattery);
    }


    public void SubstractHealth(int substract)
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
    }
}
