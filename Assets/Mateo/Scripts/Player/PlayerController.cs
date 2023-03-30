using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class PlayerController : Controller
{
    #region Params
    public static PlayerController _playerController { get; private set; }
    public Rigidbody _rb { get; private set; }
    public CapsuleCollider _capscol { get; private set; }

    public Renderer rende;

    public float battery;

    [Range(0,1)]
    public float inputChangeDif;

    [HideInInspector] public PlayerStates playerState;
    #endregion

    //Events
    [HideInInspector] public bool hasReceivedEvent = true;
    [HideInInspector] public Event receivedEvent;

    private void Awake()
    {
        if (_playerController != null && _playerController != this)
            Destroy(this);
        else
            _playerController = this;
    }

    public override void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _capscol = GetComponent<CapsuleCollider>();

        base.Start();
    }
}
