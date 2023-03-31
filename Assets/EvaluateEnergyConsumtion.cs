using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Action/EvaluateEnergyConsumtion", fileName = "EvaluateEnergyConsumtion")]
public class EvaluateEnergyConsumtion : Action
{
    [SerializeField]
    private int maxBattery;

    /*[Tooltip("Duracion de recarga con potis")]
    [SerializeField]
    private float healDuration;*/
    [Tooltip("Duracion de recarga de bateria")]
    [SerializeField]
    private float rechargeDuration;

    /*[Tooltip("Duracion de la substraccion de bateria")]
    [SerializeField]
    private float substractVelocity;*/
    [Tooltip("Duracion de la autosubstraccion de bateria")]
    [SerializeField]
    private float autoSubstractVelocity;

    [SerializeField]
    private bool curation;

    [Header("La bateria se consume sola")]
    [SerializeField]
    private bool autoConsum;

    private PlayerController playerController;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;

        playerController.battery = maxBattery;
        curation = false;
    }

    public override void Act(Controller controller)
    {
        if (curation)
        {
            playerController.battery += Time.fixedDeltaTime * (maxBattery / rechargeDuration);
        }
        else if (autoConsum)
        {
            playerController.battery -= Time.fixedDeltaTime * (maxBattery / autoSubstractVelocity);
        }
    }
}