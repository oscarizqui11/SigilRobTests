using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections;

public class Detector : MonoBehaviour
{
    public Cambot cambot;

    private void OnTriggerEnter(Collider other)
    {
        cambot.persecution = true;
    }
}
