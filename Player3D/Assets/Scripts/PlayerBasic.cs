using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBasic : MonoBehaviour, Controls.IPlayerActions
{
    private CharacterController Controller;
    private Controls Controls;
    private Vector2 InputDirection;
    private Vector3 MovementDirection;
    private Animator Animator;
    [SerializeField]
    private float Speed = 2.5f;
    [SerializeField]
    private float AnimationDamping = 0f;
    [SerializeField]
    private float RotationDamping = 0f;
    private int ParameterId = Animator.StringToHash("Blend");


    public void OnJump(InputAction.CallbackContext context)
    {
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        InputDirection = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Estas tres líneas son necesarias para usar el nuevo tipo de Mapeo en Unity
        Controls = new Controls();
        Controls.Player.SetCallbacks(this);
        Controls.Player.Enable();

        Controller = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Los valores de Y los convierte a Z
        MovementDirection = new Vector3(
            InputDirection.x,
            0,
            InputDirection.y
        );

        Controller.Move(MovementDirection * Time.deltaTime * Speed);

        // No rotes a no ser que rotes alguna de las teclas
        if (InputDirection.magnitude != 0)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(MovementDirection),
                RotationDamping * Time.deltaTime 
            );
            Animator.SetFloat(ParameterId, 1f, AnimationDamping, Time.deltaTime); // Activa la animación
        }
        else
        {
            Animator.SetFloat(ParameterId, 0f, AnimationDamping, Time.deltaTime); // Desactiva la animación
        }
    }

    private void OnDisable()
    {
        // Cuando el objeto es destruido o desactivado, es necesario deshabilitar los controles
        Controls.Player.Disable();
    }
}
