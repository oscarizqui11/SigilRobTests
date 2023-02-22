using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation_", menuName = "Dialogue/New Conversation")]
public class Conversation : ScriptableObject
{
    [SerializeField] private Dialogue[] allLines;

    public Dialogue GetLineByIndex(int index)
    { return allLines[index]; }

    public int GetLength()
    { return allLines.Length - 1; }
}
