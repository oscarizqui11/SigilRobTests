using UnityEngine;
using FSM;
using UnityEngine.InputSystem;

public abstract class EvaluateShootInput : Action
{
    public InputAction shootingAction;
    public float cadency;
    public string bulletName;
    public Vector3 gunPosition;

    protected float time;
    private PlayerController playerController;

    public int energyCost;

    public override void Innit(Controller controller)
    {
        playerController = (PlayerController)controller;
        shootingAction.Enable();
        
        time = cadency;
    }

    public override void Act(Controller controller)
    {
        time = time + Time.deltaTime;

        if (shootingAction.triggered && time >= cadency)
        {
            Shoot(playerController.transform);
            
            playerController.GetComponent<PlayerController>().battery -= energyCost;
            time = 0;
        }
    }

    public abstract void Shoot(Transform transform);
}
