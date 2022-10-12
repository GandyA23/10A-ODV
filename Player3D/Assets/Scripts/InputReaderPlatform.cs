using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReaderPlatform : MonoBehaviour, PlatformControls.IActionsPlatformsActions
{
    public Vector2 MovementValue { get; private set; }
    private PlatformControls controls;
    public event Action RotateEvent;
    public event Action MoveEvent;

    public void Start()
    {
        controls = new PlatformControls();
        controls.ActionsPlatforms.SetCallbacks(this);
        controls.ActionsPlatforms.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        MoveEvent?.Invoke();
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        RotateEvent?.Invoke();
    }

    public void OnDestroy()
    {
        controls.ActionsPlatforms.Disable();
    }
}
