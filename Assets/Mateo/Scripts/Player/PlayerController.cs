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

    public Renderer rende;

    public PlayerState playerState;

    public float battery;

    public Transform objectDraggable;

    [SerializeField]
    private bool curation;
    [SerializeField]
    private bool autoConsum;

    private Vector3 movDir;
    private bool jumpUsed;
    private bool isShooting;
    private bool JetpackActive;
    #endregion

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

    public void SetJump(bool isUsed)
    {
        jumpUsed = isUsed;
    }
    public bool GetJump()
    {
        return jumpUsed;
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

    public void SetShootingActive(bool isShoot)
    {
        isShooting = isShoot;
    }
    public bool GetShootingActive()
    {
        return isShooting;
    }

    public void SetJetpackActive(bool isJpActive)
    {
        JetpackActive = isJpActive;
    }
    public bool GetJetpackActive()
    {
        return JetpackActive;
    }
}
