using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    private float verticalVelocity;
    public Vector3 Movement => Vector3.up * verticalVelocity;

    // Update is called once per frame
    private void Update()
    {
        // Verifica si el usuario se encuentra sobre el suelo
        // En caso de que verticalVelocity sea menor a 0 (cayendo)
        // isGrounded ya esta definido dentro del CharacterController
        // Physics.gravity.y esta definido en Project Settings (Actual: -9.81)
        if (verticalVelocity < 0f && controller.isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else 
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }
}
