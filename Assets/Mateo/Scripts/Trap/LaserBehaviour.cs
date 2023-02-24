using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    #region Parameters
    [SerializeField] private Vector3[] pos = new Vector3[2];
    [SerializeField] private float speed;
    [SerializeField] private string mirrorLayer;

    public bool Active_ { private get; set; }

    private LineRenderer lr_;
    #endregion

    #region Interpolation
    private float totalTime;
    private float factor;
    private float currentTime;

    private bool assignedPoint;

    private Vector3 dir;
    private Vector3 pointA;
    private Vector3 pointB;
    #endregion

    private void Start()
    {
        pointA = pos[0];
        pointB = pos[1];

        lr_ = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        Movement();
        Action();
    }

    private void Movement()
    {
        if (!assignedPoint)
        {
            float dist = Vector3.Distance(pointA, pointB);

            totalTime = dist / speed;
            assignedPoint = true;

            dir = (pointB - pointA).normalized;
        }

        currentTime += Time.deltaTime;
        factor = currentTime / totalTime;

        Vector3 valueIPos = pointA + (pointB - pointA) * factor;
        transform.position = valueIPos;

        if (currentTime > totalTime)
        {
            currentTime = 0;
            assignedPoint = false;

            var pointC = pointA;
            pointA = pointB;
            pointB = pointC;
        }
    }

    private void Action()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 25))
        {
            lr_.positionCount = 2;
            lr_.SetPosition(0, transform.position);
            lr_.SetPosition(1, hit.point);

            ReflectLaser(hit, 1);
        }
    }

    private void ReflectLaser(RaycastHit hit, int index)
    {
        if (LayerMask.LayerToName(hit.transform.gameObject.layer) == mirrorLayer)
        {
            var direction = Vector3.Reflect(transform.forward, hit.normal);
            Ray ray_ = new Ray(hit.point, direction);
            RaycastHit hit_;

            if (Physics.Raycast(ray_, out hit_, 25))
            {
                index++;
                lr_.positionCount++;
                lr_.SetPosition(index, hit_.point);
                
                ReflectLaser(hit_, index); 
            }
        }
    }
}
