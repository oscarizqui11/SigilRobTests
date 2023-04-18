using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambot_Area : MonoBehaviour
{
    public Cambot cambot;
    private void OnTriggerExit(Collider other)
    {
        cambot.persecution = false;
    }
}
