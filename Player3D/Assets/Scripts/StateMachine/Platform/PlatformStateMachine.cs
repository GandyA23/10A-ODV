using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStateMachine : StateMachine
{
    [field: SerializeField] public InputReaderPlatform InputReader { get; private set; }
    public void Start()
    {
        SwitchState(new RotatingState(this));
    }
}
