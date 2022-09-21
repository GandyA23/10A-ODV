using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    // Velocidad en la cuál se va a mover la plataforma
	[SerializeField] private float speed = 10f;

	// Realiza el movimiento de la plataforma
    // Update is called once per frame
    void Update () 
    {
        // Esta plataforma se mueve en x positivo (derecha)
        transform.position += Vector3.right * speed * Time.deltaTime;
    
        // Si la plataforma se movió más de 10 unidades, entonces destruye el objeto
        if (transform.position.x > 10f) 
        {
            Destroy(this.gameObject);
        }
    }
}
