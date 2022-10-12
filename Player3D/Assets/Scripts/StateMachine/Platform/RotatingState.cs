using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingState : PlatformBaseState
{
    private float angle = 40f;

    public RotatingState(PlatformStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        // Llama al siguiente evento
        stateMachine.InputReader.MoveEvent += OnMove;
    }

    private void OnMove()
    {
        stateMachine.SwitchState(new MovingState(stateMachine));
    }

    public override void Tick(float deltaTime)
    {
        // Rotar en base al eje Y
        stateMachine.transform.Rotate(Vector3.up, angle * deltaTime);
    }

    public override void Exit()
    {
        // Desuscribete del siguiente evento
        stateMachine.InputReader.MoveEvent -= OnMove;
    }
}
