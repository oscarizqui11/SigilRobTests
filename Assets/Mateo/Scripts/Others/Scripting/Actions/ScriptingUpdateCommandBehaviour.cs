using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Scripting/Action/ScriptingUpdateCommandBehaviour", fileName = "UpdateCommand")]
public class ScriptingUpdateCommandBehaviour : Action
{
    private ScriptingManager scriptingManager;
    private bool boolean;

    public override void Innit(Controller controller)
    {
    }

    public override void Act(Controller controller)
    {
        scriptingManager = (ScriptingManager)controller;

        Script s = scriptingManager._script;
        int index = scriptingManager.index;

        switch (s.commands[index].scriptingActType)
        {
            case Script.Command.ScriptingActType.talk:
                boolean = DialogueManager.speaking;
                break;
            case Script.Command.ScriptingActType.moveCamera:
                boolean = CameraManager._cameraManager.MoveCamera(s.commands[index].varVector1, s.commands[index].varVector2, s.commands[index].varFloat1, s.commands[index].varFloat2);
                break;
            case Script.Command.ScriptingActType.moveCameraPos:
                boolean = CameraManager._cameraManager.MoveCameraPos(s.commands[index].varVector1, s.commands[index].varFloat1);
                break;
            case Script.Command.ScriptingActType.moveCameraRot:
                boolean = CameraManager._cameraManager.MoveCameraRot(s.commands[index].varVector2, s.commands[index].varFloat2);
                break;
            case Script.Command.ScriptingActType.wait:
                scriptingManager.timer -= Time.deltaTime;

                if (scriptingManager.timer <= 0)
                    boolean = false;
                else
                    boolean = true;
                break;
        }

        scriptingManager.waiting = boolean;
    }
}
