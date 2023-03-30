using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class GameManager : Controller
{
    public static GameManager _gameManager { get; private set; }

    public List<Controller> controllers = new List<Controller>();

    //Events
    [HideInInspector] public bool hasReceivedEvent = true;
    [HideInInspector] public Event receivedEvent;

    public int gameState;

    private void Awake()
    {
        if (_gameManager != null && _gameManager != this)
            Destroy(this);
        else
            _gameManager = this;
    }

    public override void Start()
    {
        Controller[] tempContrlls = FindObjectsOfType<Controller>();

        for (int i = 0; i < tempContrlls.Length; i++)
        {
            if (tempContrlls[i] != this)
                controllers.Add(tempContrlls[i]);
        }

        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}
