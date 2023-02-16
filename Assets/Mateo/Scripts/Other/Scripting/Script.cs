using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Script_", menuName = "Scripting/Script")]
public class Script : ScriptableObject
{
    public int ArrayLeght;
    public Command[] commands;
    [System.Serializable]
    public class Command
    {
        public enum ScriptingActType
        {
            talk,
            moveCamera,
            playAudio,
            stopAudio,
            wait
        };
        public ScriptingActType scriptingActType;

        public Conversation conver;
        public Vector3 varVector1;
        public Vector3 varVector2;
        public string varString;
        public float varFloat1;
        public float varFloat2;
    }
}
