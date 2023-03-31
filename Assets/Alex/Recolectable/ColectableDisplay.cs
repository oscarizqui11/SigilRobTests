using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColectableDisplay : MonoBehaviour
{
    public NotesScript note;

    //public Text names;
    public TextMeshProUGUI names;
    public TextMeshProUGUI descriptions;
    public Image backgrounds;
    public void Recharge()
    {
        names.text = note.name;
        descriptions.text = note.description;
        backgrounds.sprite = note.background;
    }
}
