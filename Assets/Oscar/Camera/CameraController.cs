using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SRobEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Camera _cam;
    private Transform _player;
    [SerializeField] FixedCamera activeCamera;

    private bool isFirstPerson;
    private Vector3 fixedCamPosition;
    private Quaternion fixedCamRotation;
    private float xRotation;
    [SerializeField] float camSensibility = 100;
    [SerializeField] float camHeight;

    public MeshRenderer[] meshesToDisabel;

    public InputAction firstPersonAction;

    void Start()
    {
        firstPersonAction.Enable();

        _cam = GetComponent<Camera>();
        _player = FindObjectOfType<PlayerController>().transform;
     
        fixedCamPosition = _cam.transform.position;
        fixedCamRotation = _cam.transform.rotation;
    }

    void Update()
    {
        /*if(Input.GetButtonDown("FirstPerson") && _player.GetComponent<JumpController>().Grounded)
        {
            ToggleFirstPerson();
        }
        else if(isFirstPerson)
        {
            if (Mathf.Abs(_player.transform.position.x - _cam.transform.position.x) > 0.5f ||
                Mathf.Abs(_player.transform.position.z - _cam.transform.position.z) > 0.5f)
            {
                ToggleFirstPerson();
            }
            else
            {
                float mouseX = Input.GetAxisRaw("Mouse X") * camSensibility * Time.deltaTime;
                xRotation += Input.GetAxisRaw("Mouse Y") * camSensibility * Time.deltaTime;

                xRotation = Mathf.Clamp(xRotation, -80, 80);

                _cam.transform.eulerAngles = new Vector3(-xRotation, _cam.transform.eulerAngles.y + mouseX, 0);
                _player.transform.Rotate(0, mouseX, 0);
            }

        }*/
    }

    public void ToggleFirstPerson()
    {
        isFirstPerson = !isFirstPerson;

        for(int i = 0; i < meshesToDisabel.Length; i++)
        {
            Debug.Log("Desactiva Cabezas");
            meshesToDisabel[i].enabled = !isFirstPerson;
        }

        if(isFirstPerson)
        {
            _cam.transform.position = _player.position + new Vector3(0, camHeight, 0);
            _cam.transform.rotation = _player.rotation;
        }
        else
        {
            _cam.transform.position = fixedCamPosition;
            _cam.transform.rotation = fixedCamRotation;
        }
    }

    public bool GetIsFirstPerson()
    {
        return isFirstPerson;
    }

    public void SetCameraPosition(Vector3 newPos)
    {
        _cam.transform.position = newPos;
        fixedCamPosition = newPos;
    }

    public void SetCameraRotation(Quaternion newRotation)
    {
        _cam.transform.rotation = newRotation;
        fixedCamRotation = newRotation;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(activeCamera)
            activeCamera.PreviewCamera();
    }
#endif
}
