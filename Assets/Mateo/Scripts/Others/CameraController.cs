using UnityEngine;
using SRobEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Camera _cam;
    private Transform _player;
    //[SerializeField] FixedCamera activeCamera;

    public bool isFirstPerson { private set; get; }
    private Vector3 fixedCamPosition;
    private Quaternion fixedCamRotation;
    private float xRotation;

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
    //private void OnDrawGizmos()
    //{
    //    if(activeCamera)
    //        activeCamera.PreviewCamera();
    //}
#endif
}
