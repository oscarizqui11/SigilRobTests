using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Notes", menuName = "Collectables/Note")]
public class NotesScript : ScriptableObject
{
    public bool active;
    public new string name;
    public string description;
    public int ID;
    public Sprite background;
    public bool collected;
}
