using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Area : MonoBehaviour
{
    public Turret turret;
    private void OnTriggerEnter(Collider other)
    {
        turret.vision = true;
        turret.target = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        turret.vision = false;
    }
}
