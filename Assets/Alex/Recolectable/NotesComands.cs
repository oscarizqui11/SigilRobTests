using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NotesComands : MonoBehaviour
{
    public GameObject panel;
    public GameObject inventory;
    public NotesScript globalNote;
    private bool fromInvent;

    public InputAction cancelAction;

    private void OnEnable()
    {
        cancelAction.Enable();
    }

    public void OpenNote(NotesScript nota, bool fromInv)
    {
        fromInvent = fromInv;
        globalNote = nota;
        panel.SetActive(true);
        panel.GetComponent<ColectableDisplay>().note = globalNote;
        panel.GetComponent<ColectableDisplay>().Recharge();
        globalNote.active = true;
    }
    public void CloseNote(NotesScript nota)
    {
        globalNote = nota;
        globalNote.active = false;
        panel.SetActive(false);
        if(fromInvent == true)
        {
            OpenInventory(globalNote);
        }
    }

    public void OpenInventory(NotesScript nota)
    {
        globalNote = nota;
        globalNote.active = false;
        panel.SetActive(false);
        inventory.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseInventory(NotesScript nota)
    {
        globalNote = nota;
        globalNote.active = false;
        inventory.SetActive(true);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (globalNote.active == true && cancelAction.triggered)
        {
            OpenInventory(globalNote);
        }
    }
}
