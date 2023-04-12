using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private List<LaserData> laserData = new List<LaserData>();

    private LaserMovementBehaviour laserMovement;
    private LaserActionBehaviour laserAction;

    private void Start()
    {
        laserMovement = GetComponent<LaserMovementBehaviour>();
        laserAction = GetComponent<LaserActionBehaviour>();

        foreach(Transform child in transform)
            laserData.Add(child.GetComponent<LaserData>());

        for (int i = 0; i < laserData.Count; i++)
            laserData[i].lr_ = laserData[i].GetComponent<LineRenderer>();
    }

    private void Update()
    {
        for (int i = 0; i < laserData.Count; i++)
        {
            laserMovement.Movement(laserData[i]);
            laserAction.Action(laserData[i]);
        }
    }
}
