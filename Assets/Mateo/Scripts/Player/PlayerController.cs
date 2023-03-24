using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class PlayerController : Controller
{
    public static PlayerController _playerController { get; private set; }
    public Rigidbody _rb { get; private set; }
    public CapsuleCollider _capscol { get; private set; }

    [Range(0,1)]
    public float inputChangeDif;

    public enum PlayerState
    {
        Grounded,
        Airborne,
        Shooting,
        Holding,
        Healing
    };
    [HideInInspector] public PlayerState playerState;

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

    public override void Update()
    {
        base.Update();
    }
}
