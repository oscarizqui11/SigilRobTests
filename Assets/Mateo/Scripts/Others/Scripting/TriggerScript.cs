using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] private Script _script;
    [SerializeField] private ScriptingManager _scriptingManager;

    private void OnTriggerEnter(Collider other)
    {
        _scriptingManager._script = _script;
        enabled = false;
    }
}
