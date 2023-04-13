using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private List<Transform> laserData = new List<Transform>();

    private List<LaserMovementBehaviour> laserMovementBehaviours = new List<LaserMovementBehaviour>();
    private List<LaserActionBehaviour> laserActionBehaviours = new List<LaserActionBehaviour>();

    private void Start()
    {
        foreach(Transform child in transform)
            if (child.GetComponent<LaserMovementBehaviour>() && child.GetComponent<LaserActionBehaviour>())
                laserData.Add(child);

        for (int i = 0; i < laserData.Count; i++)
        {
            laserMovementBehaviours.Add(laserData[i].GetComponent<LaserMovementBehaviour>());
            laserActionBehaviours.Add(laserData[i].GetComponent<LaserActionBehaviour>());

            laserActionBehaviours[i].lr_ = laserData[i].GetComponent<LineRenderer>();
        }
    }

    private void Update()
    {
        for (int i = 0; i < laserData.Count; i++)
        {
            laserMovementBehaviours[i].Movement();
            laserActionBehaviours[i].DisplayLaser();
        }
    }
}
