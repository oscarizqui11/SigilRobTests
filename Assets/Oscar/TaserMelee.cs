using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserMelee : MonoBehaviour
{
    [SerializeField, Range(0, 5)]
    float taserDuration = 1f;

    float taserTimer = 0f;

    private void OnEnable()
    {
        taserTimer = taserDuration;
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
            gameObject.SetActive(false);
        }
    }
}
