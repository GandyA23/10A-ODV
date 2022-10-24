using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine) 
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        // motion = desplazamiento
        // Haz que mi objeto caiga
        stateMachine.CharacterController.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }

    protected void FaceTarget()
    {
        // FaceTarget se encarga de rotar para ver bien al objetivo
        if (stateMachine.Targeter.CurrentTarget == null) { return; }
        
        // Obten un vector entre dos objetos
        Vector3 lookPos = 
            stateMachine.Targeter.CurrentTarget.transform.position - 
            stateMachine.transform.position;

        lookPos.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }
}
