using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    // Controles
    [field: SerializeField] public InputReader InputReader { get; private set; }
    
    // Movimiento
    [field: SerializeField] public CharacterController CharacterController { get; private set; }
    
    // Animaciones
    [field: SerializeField] public Animator Animator { get; private set; }
    
    // Objetivos
    [field: SerializeField] public Targeter Targeter { get; private set; }

    // Físicas durante movimiento
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    
    [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }
    [field: SerializeField] public float RotationDamping { get; private set; }
    [field: SerializeField] public float TargetingMovementSpeed { get; private set; }
    public Transform MainCameraTransform { get; private set; }

    void Start()
    {
        SwitchState(new PlayerFreeLookState(this));
        MainCameraTransform = Camera.main.transform;
    }
}
