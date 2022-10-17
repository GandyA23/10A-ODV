using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : PlatformBaseState
{

    private float speed = 5f;

    public MovingState(PlatformStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.RotateEvent += OnRotate;
    }

    private void OnRotate()
    {
        stateMachine.SwitchState(new RotatingState(stateMachine));
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.transform.Translate(Vector3.forward * speed * deltaTime);
    }

    public override void Exit()
    {
        stateMachine.InputReader.RotateEvent -= OnRotate;
    }
}
