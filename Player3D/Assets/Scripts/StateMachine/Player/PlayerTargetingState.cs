using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{

    private readonly int targetingBlendTreeHash = Animator.StringToHash("TargetingBlendTree");

    public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        // Empieza a reproducir la animación
        stateMachine.Animator.Play(targetingBlendTreeHash);
        stateMachine.InputReader.CancelEvent += OnCancel;
    }

    public override void Exit()
    {
        stateMachine.InputReader.CancelEvent -= OnCancel;
    }

    public override void Tick(float deltaTime)
    {
        // Verifica que el CurrentTarget siga vivo o se encuentre en mi rango para continuar en este estado
        if (stateMachine.Targeter.CurrentTarget == null)
        {
            OnCancel();
            return;
        }

        // Muevete gracias al método heredado de PlayerBaseState
        Vector3 movement = CalculateMovement();
        Move(movement * stateMachine.TargetingMovementSpeed, deltaTime);

        FaceTarget();
    }

    private void OnCancel()
    {
        // Elimina al actual Target
        stateMachine.Targeter.Cancel();

        // Cuando cancela el Targeting, debes de pasar de nuevo al FreeLookState
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }

    private Vector3 CalculateMovement()
    {
        // Calcula el movimiento de la rotación
        Vector3 movement = new Vector3();

        movement += stateMachine.transform.right * stateMachine.InputReader.MovementValue.x;
        movement += stateMachine.transform.forward * stateMachine.InputReader.MovementValue.y;

        return movement;
    }
}
