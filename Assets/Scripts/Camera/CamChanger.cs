using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SRobEngine;

public class CamChanger : MonoBehaviour
{
    [SerializeField] FixedCamera cam;

    private void OnTriggerEnter(Collider other)
    {
        Camera.main.GetComponent<CameraController>().SetCameraPosition(cam.GetPosition());
        Camera.main.GetComponent<CameraController>().SetCameraRotation(Quaternion.Euler(cam.GetEulerRotation()));
    }
}
