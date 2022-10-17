using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{
    public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.CancelEvent += OnCancel;
    }

    public override void Exit()
    {
        stateMachine.InputReader.CancelEvent -= OnCancel;
    }

    public override void Tick(float deltaTime)
    {
    }

    private void OnCancel()
    {
        // Elimina al actual Target
        stateMachine.Targeter.Cancel();

        // Cuando cancela el Targeting, debes de pasar de nuevo al FreeLookState
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }
}
