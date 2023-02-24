using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChanger : MonoBehaviour
{
    [SerializeField] Vector3 camPosition;
    [SerializeField] Vector3 camRotation;

    private void OnTriggerEnter(Collider other)
    {
        Camera.main.GetComponent<CameraController>().SetCameraPosition(camPosition);
        Camera.main.GetComponent<CameraController>().SetCameraRotation(Quaternion.Euler(camRotation));
    }
}
