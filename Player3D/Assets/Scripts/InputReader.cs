using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Esta clase nos ayuda a filtrar la entrada
public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }
    public event Action JumpEvent;
    public event Action TargetEvent;
    public event Action CancelEvent;
    private Controls controls;

    // Start is called before the first frame update
    void Start()
    {
        controls = new Controls();

        // Configura los callbacks de OnJump y OnMove para poder realizar las acciones con el jugador
        controls.Player.SetCallbacks(this);
        
        // Habilita esos callbacks
        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {   
        // Verifica que haya presionado el/los botón/botones [Keyboard : Espacio] para realizar el evento
        if (!context.performed) return;
        JumpEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Debido a que es movimiento, entonces es necesario solo pasarle el Vector2 del contexto
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnTarget(InputAction.CallbackContext context)
    {
        // Verifica que haya presionado el/los botón/botones [Keyboard : Tab] para realizar el evento
        if (!context.performed) return;
        TargetEvent?.Invoke();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        // Verifica que haya presionado el/los botón/botones [Keyboard : Escape] para realizar el evento
        if (!context.performed) return;
        CancelEvent?.Invoke();
    }
}
