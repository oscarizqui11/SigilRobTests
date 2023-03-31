using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public struct Note
    {
        public GameObject boton;
        public NotesScript nota;
    };

    public GameObject panel;
    public GameObject inventory;
    public GameObject noteComands;

    public Note[] notes;

    void Update()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            if (notes[i].nota.collected == true)
            {
                notes[i].boton.SetActive(true);
            }
            else
            {
                notes[i].boton.SetActive(false);
            }
        }
    }

    public void OpenNote(int index)
    {
        noteComands.GetComponent<NotesComands>().OpenNote(notes[index - 1].nota, true);
        inventory.SetActive(false);
    }
}
