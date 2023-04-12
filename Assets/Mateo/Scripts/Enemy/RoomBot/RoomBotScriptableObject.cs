using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/RoomBot/ScriptableObject", fileName = "RoomBotScriptableObject")]
public class RoomBotScriptableObject : ScriptableObject
{
    public float Speed { get { return speed; } }
    public float SpeedRot { get { return speedRotation; } }

    public Vector3 BoxLoc { get { return boxLocation; } }
    public Vector3 BoxSize { get { return boxSize; } }

    public LayerMask PlayerMask { get { return playerMask; } }
    public Color Color { get { return color; } }

    public float CDMax { get { return cooldownMax; } }
    public float Bounce { get { return bounce; } }


    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;

    [Header("Collider Parameters")]
    [SerializeField] private Vector3 boxLocation;
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private LayerMask playerMask;

    [Header("Reactivated Parameters")]
    [SerializeField] protected Color color;
    [SerializeField] protected float cooldownMax;

    [Header("Special Parameters")]
    [SerializeField] private float bounce;
}
