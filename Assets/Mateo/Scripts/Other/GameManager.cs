using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class GameManager : Controller
{
    public static GameManager _gameManager { get; private set; }

    [System.Serializable]
    public struct Controllers 
    { 
        public int GameState;
        public Controller controller;
    }
    public Controllers[] controllers;

    //Events
    [HideInInspector] public bool hasReceivedEvent = true;
    [HideInInspector] public Event receivedEvent;

    [HideInInspector] public int gameState;

    private void Awake()
    {
        if (_gameManager != null && _gameManager != this)
            Destroy(this);
        else
            _gameManager = this;
    }

    public override void Start()
    {
        for (int i = 0; i < controllers.Length; i++)
            controllers[i].controller.enabled = false;

        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}
