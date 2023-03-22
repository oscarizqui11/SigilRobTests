using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class GameManager : Controller
{
    public static GameManager _gameManager { get; private set; }

    [SerializeField] public int[] GameState;
    [SerializeField] private Controller[] controllers;

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
        controllers = FindObjectsOfType<Controller>();

        for (int i = 0; i < controllers.Length; i++)
            controllers[i].enabled = false;

        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}
