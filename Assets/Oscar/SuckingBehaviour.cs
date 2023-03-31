using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckingBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            player.SetAutoConsumption(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            player.SetAutoConsumption(false);
        }
    }
}
