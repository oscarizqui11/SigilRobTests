using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Scripting/Decision/DecScriptingChangeState", fileName = "DecScriptingChangeState")]
public class DecScriptingChangeState : Decision
{
    [SerializeField] private bool waiting;

    public override bool Decide(Controller controller)
    {
        ScriptingManager ScriptingManager = (ScriptingManager)controller;

        if (ScriptingManager.waiting == waiting)
            return true;
        else
            return false;
    }
}
