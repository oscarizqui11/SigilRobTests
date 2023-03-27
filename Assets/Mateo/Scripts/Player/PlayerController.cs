using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using SRobEngine.SRobPlayer;

namespace SRobEngine
{
    namespace SRobPlayer
    {
        public enum PlayerState
        {
            Grounded,
            Airborne,
            Ramming,
            Shooting,
            Holding,
            Healing
        };
    }
}

public class PlayerController : Controller
{
    #region Param
    public static PlayerController _playerController { get; private set; }
    public Rigidbody _rb { get; private set; }
    public CapsuleCollider _capscol { get; private set; }
    public MovementBH _mb { get; private set; }

    public Renderer rende;

    public float battery;
    
    [HideInInspector] public PlayerState playerState;
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
        _mb = GetComponent<MovementBH>();
        _rb = GetComponent<Rigidbody>();
        _capscol = GetComponent<CapsuleCollider>();

        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}
