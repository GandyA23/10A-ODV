using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{

    private readonly int TargetingBlendTreeHash = Animator.StringToHash("TargetingBlendTree");
    private readonly int TargetingForwardHash = Animator.StringToHash("TargetingForward");
    private readonly int TargetingRightHash = Animator.StringToHash("TargetingRight");

    public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        // Empieza a reproducir la animación
        stateMachine.Animator.Play(TargetingBlendTreeHash);
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

        // Actualiza las animaciones dependiendo los valores Float
        // TargetingForwardHash y TargetingRightHash
        UpdateAnimator(deltaTime);
    }

    private void UpdateAnimator(float deltaTime)
    {
        if (stateMachine.InputReader.MovementValue.y == 0)
        {
            stateMachine.Animator.SetFloat(TargetingForwardHash, 0, 0.5f, deltaTime);
        }

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
