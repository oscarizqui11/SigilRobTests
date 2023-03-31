using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.TryGetComponent<HealthBehaviour>(out HealthBehaviour h));
        if(other.TryGetComponent<PlayerController>(out PlayerController healthy))
        {
            healthy.SetAutoCuration(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController healthy))
        {
            healthy.SetAutoCuration(false);
        }
    }
}
