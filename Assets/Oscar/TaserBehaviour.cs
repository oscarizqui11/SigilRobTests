using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserBehaviour : MonoBehaviour
{
    HealthBehaviour _energySystem;

    [SerializeField]
    Transform taser;

    [SerializeField, Range(0, 5)]
    float taserDuration = 1f;
    [SerializeField]
    int energyCost;

    float taserTimer = 0f;

    private void Start()
    {
        _energySystem = GetComponent<HealthBehaviour>();
    }

    void Update()
    {
        /*if(Input.GetButtonDown("Fire1"))
        {
            _energySystem.SubstractHealth(energyCost);
            taser.gameObject.SetActive(true);
            taserTimer = taserDuration;
        }*/
    }

    private void FixedUpdate()
    {
        if(taserTimer > 0)
        {
            taserTimer -= Time.fixedDeltaTime;
        }
        else
        {
            taserTimer = 0f;
            taser.gameObject.SetActive(false);
        }
    }
}
