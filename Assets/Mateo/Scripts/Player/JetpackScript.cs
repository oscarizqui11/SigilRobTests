using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackScript : MonoBehaviour
{
    private bool JetpackActive;
    private bool DoubleJumpUsed;

    public void SetJetpackActive(bool isJpActive)
    {
        JetpackActive = isJpActive;
    }
    public bool GetJetpackActive()
    {
        return JetpackActive;
    }

    public void SetDoubleJump(bool dj)
    {
        DoubleJumpUsed = dj;
    }
    public bool GetDoubleJump()
    {
        return DoubleJumpUsed;
    }
}
