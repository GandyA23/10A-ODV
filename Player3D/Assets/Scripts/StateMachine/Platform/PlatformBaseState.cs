using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformBaseState : State
{
    protected PlatformStateMachine stateMachine;

    public PlatformBaseState (PlatformStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
