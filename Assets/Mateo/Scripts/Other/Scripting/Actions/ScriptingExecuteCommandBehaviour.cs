using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Scripting/Action/ScriptingExecuteCommandBehaviour", fileName = "ExecuteCommand")]
public class ScriptingExecuteCommandBehaviour : Action
{
    private ScriptingManager scriptingManager;

    public override void Act(Controller controller)
    {
        scriptingManager = (ScriptingManager)controller;

        Script s = scriptingManager._script;
        int index = scriptingManager.index;

        switch (s.commands[index].scriptingActType)
        {
            case Script.Command.ScriptingActType.talk:
                DialogueManager._dialogueManager.StartConversation(s.commands[index].conver);
                break;
            case Script.Command.ScriptingActType.playMusic:
                AudioManager._audioManager.PlayMusic(s.commands[index].varString);
                break;
            case Script.Command.ScriptingActType.playSFX:
                AudioManager._audioManager.PlaySFX(s.commands[index].varString);
                break;
            case Script.Command.ScriptingActType.playVoice:
                AudioManager._audioManager.PlayVoice(s.commands[index].varString);
                break;
            case Script.Command.ScriptingActType.stopMusic:
                AudioManager._audioManager.StopMusic(s.commands[index].varString);
                break;
            case Script.Command.ScriptingActType.wait:
                scriptingManager.timer = s.commands[index].varFloat1;
                break;
        }

        scriptingManager.waiting = true;
    }
}
