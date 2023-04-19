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
            Healing,
            FirstPerson
        };
    }
}

public class PlayerController : Controller
{
    #region Params
    public static PlayerController _playerController { get; private set; }
    public Rigidbody _rb { get; private set; }
    public CapsuleCollider _capscol { get; private set; }
    public MovementBH _mb { get; private set; }
    public JetpackScript _jp { get; private set; }

    public Renderer rende;

    public PlayerState playerState;

    public float battery;

    [SerializeField]
    private bool curation;
    [SerializeField]
    private bool autoConsum;

    private Vector3 movDir;
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
        _mb = GetComponent<MovementBH>();
        _jp = GetComponent<JetpackScript>();

        base.Start();
    }

    public void SetDir(Vector3 dir)
    {
        movDir = dir;
    }
    public Vector3 GetDir()
    {
        return movDir;
    }

    public void SetAutoCuration(bool cur)
    {
        curation = cur;
    }
    public bool GetAutoCuration()
    {
        return curation;
    }

    public void SetAutoConsumption(bool cons)
    {
        autoConsum = cons;
    }
    public bool GetAutoConsumption()
    {
        return autoConsum;
    }
}
