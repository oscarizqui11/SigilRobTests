using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public MyVec3Event Response;

    private void OnEnable() => Event.RegisterListener(this);

    private void OnDisable() => Event.UnregisterListener(this);

    public void OnEventRaised(Vector3 vec3) => Response.Invoke(vec3);
}

