using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Action/ScriptingManager")]
public abstract class ScriptingManager : Action
{
    public Script _script { private get; set; }

    private GameManager _gameManager;

    private int index;
    private float timer;
    private bool waiting;

    public override void Innit(Controller controller)
    {
        //_gameManager = (GameManager)controller;
    }

    public override void Act(Controller controller)
    {
        if (index >= _script.commands.Length)
        {
            _gameManager.gameState = 0;
            index = 0;
            waiting = false;
        }
        else
        {
            if (waiting)
                waiting = UpdateCommand(_script);
            else
                waiting = ExecuteCommand(_script);

            if (!waiting)
                index++;
        }
    }

    private bool ExecuteCommand(Script s)
    {
        bool boolean = false;

        switch (s.commands[index].scriptingActType)
        {
            case Script.Command.ScriptingActType.talk:
                DialogueManager._dialogueManager.StartConversation(s.commands[index].conver);

                boolean = DialogueManager.speaking;
                break;
            case Script.Command.ScriptingActType.moveCamera:
                boolean = true;
                break;
            case Script.Command.ScriptingActType.playMusic:
                AudioManager._audioManager.PlayMusic(s.commands[index].varString);

                boolean = true;
                break;
            case Script.Command.ScriptingActType.playSFX:
                AudioManager._audioManager.PlayMusic(s.commands[index].varString);

                boolean = true;
                break;
            case Script.Command.ScriptingActType.playVoice:
                AudioManager._audioManager.PlayMusic(s.commands[index].varString);

                boolean = true;
                break;
            case Script.Command.ScriptingActType.stopMusic:
                AudioManager._audioManager.PlayMusic(s.commands[index].varString);

                boolean = true;
                break;
            case Script.Command.ScriptingActType.wait:
                timer = s.commands[index].varFloat1;

                boolean = true;
                break;
        }

        return boolean;
    }
    
    private bool UpdateCommand(Script s)
    {
        bool boolean = false;

        switch (s.commands[index].scriptingActType)
        {
            case Script.Command.ScriptingActType.talk:
                boolean = DialogueManager.speaking;
                break;
            case Script.Command.ScriptingActType.moveCamera:
                boolean = CameraManager._cameraManager.MoveCamera(s.commands[index].varVector1, s.commands[index].varVector2, s.commands[index].varFloat1, s.commands[index].varFloat2);
                break;
            case Script.Command.ScriptingActType.wait:
                timer -= Time.deltaTime;

                if (timer <= 0)
                    boolean = false;
                else
                    boolean = true;
                break;
        }

        return boolean;
    }
}