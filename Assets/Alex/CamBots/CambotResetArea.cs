using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambotResetArea : MonoBehaviour
{
    public Cambot cambot;

    private void OnTriggerEnter(Collider other)
    {
        cambot.CambotReset();
    }
}
