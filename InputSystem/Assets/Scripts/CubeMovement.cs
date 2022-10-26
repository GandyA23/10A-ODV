using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeMovement : MonoBehaviour, Controls.ICubeActions
{
    private Vector2 inputDirection;
    private Controls controls;

    public void OnMove(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controls = new Controls();
        controls.Cube.Enable();
        controls.Cube.SetCallbacks(this);
    }

    // Update is called once per frame
    void Update()
    {
        // Realiza la conversión de Vector2 a Vector3 para un movimiento lógico
        Vector3 movement = new Vector3(
            inputDirection.x,
            0,
            inputDirection.y
        );
        transform.Translate(movement);
    }
}
