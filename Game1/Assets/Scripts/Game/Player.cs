using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rbComponent;

    // forceMagnitude nos ayudará a aplicar una fuerza hacia arriba para el salto
    [SerializeField] private float forceMagnitude = 1000f;
    
    // Altura en la cuál se considera que el jugador ha perdido
    [SerializeField] private float heightLost = -10;

    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Verifica que el cubo se encuentre sobre tierra.
        isGrounded = transform.position.y < 0.7f && rbComponent.velocity.magnitude < 0.1;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            rbComponent.AddForce(Vector3.up * forceMagnitude);
        }

        if (transform.position.y < heightLost)
        {
            SceneManager.LoadScene("GameScore");
        }
    }
}
