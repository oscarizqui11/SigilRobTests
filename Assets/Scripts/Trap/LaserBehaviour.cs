using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    #region Parameters
    [SerializeField] private Vector3[] posI;
    [SerializeField] private float speed;

    public bool[] Active_;

    private Vector3 dir;
    #endregion

    #region Interpolation
    private float totalTime;
    private float factor;
    private float currentTime;

    private bool assignedPoint;

    private Vector3 pointA;
    private Vector3 pointB;
    #endregion

    private void Start()
    {
        
    }
}
