using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FSM;

public class ScriptingManager : Controller
{
    #region Params
    public static ScriptingManager _scriptingManager { get; private set; }
    public Script _script;

    public int index { private set; get; }
    public float timer;
    public bool waiting;
    #endregion

    //Events
    [HideInInspector] public bool hasReceivedEvent = true;
    [HideInInspector] public Event receivedEvent;

    private void Awake()
    {
        if (_scriptingManager != null && _scriptingManager != this)
            Destroy(this);
        else
            _scriptingManager = this;
    }

    public override void Update()
    {
        if (index >= _script.commands.Length)
        {
            GameManager._gameManager.gameState = 0;

            index = 0;
            waiting = false;
        }
        else
        {
            base.Update();

            if (!waiting)
                index++;
        }   
    }
}