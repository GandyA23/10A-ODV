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
    private float Speed = 5f;
    [SerializeField]
    private float AnimationDamping = 0.05f;
    [SerializeField]
    private float RotationDamping = 20f;
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
        //MovementDirection = new Vector3(
        //    InputDirection.x,
        //    0,
        //    InputDirection.y
        //);

        MovementDirection = CalculateMovement();

        Controller.Move(MovementDirection * Time.deltaTime * Speed);

        // No rotes a no ser que rotes alguna de las teclas
        if (InputDirection.magnitude != 0)
        {
            Vector3 movementDirection = new Vector3(
                MovementDirection.x,
                0f,
                MovementDirection.z                
            );

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(movementDirection),
                RotationDamping * Time.deltaTime 
            );
            Animator.SetFloat(ParameterId, 1f, AnimationDamping, Time.deltaTime); // Activa la animación
        }
        else
        {
            Animator.SetFloat(ParameterId, 0f, AnimationDamping, Time.deltaTime); // Desactiva la animación
        }
    }

    private Vector3 CalculateMovement()
    {
        Vector3 moveDir = Vector3.zero;

        // Accede al atributo transform de la camara
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        // Los valores hacia arriba (eje y) no me interesan para el movimiento
        forward.y = 0f;
        right.y = 0f;

        // Normaliza la magnitud
        forward.Normalize();
        right.Normalize();

        // InputDirection.y = (Teclas W S)
        // InputDirection.x = (Teclas A D)
        moveDir = forward * InputDirection.y + right * InputDirection.x;

        moveDir.y = -5;

        return moveDir;
    }

    private void OnDisable()
    {
        // Cuando el objeto es destruido o desactivado, es necesario deshabilitar los controles
        Controls.Player.Disable();
    }

    public void OnTarget(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
