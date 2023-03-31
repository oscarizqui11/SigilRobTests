using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RecolectableTrigger : MonoBehaviour
{

    private bool colectable = false;
    public GameObject panel;
    public GameObject noteComands;
    public NotesScript note;

    public InputAction collectAction;

    private void OnEnable()
    {
        collectAction.Enable();
    }


    private void OnTriggerEnter(Collider other)
    {
        //Aplicar shader
        colectable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //Desaplicar shader
        colectable = false;
    }

    private void Update()
    {
        if(colectable == true && collectAction.triggered)
        {
            noteComands.GetComponent<NotesComands>().OpenNote(note, false);
            note.collected = true;
            Destroy(gameObject);
        }
    }
}
