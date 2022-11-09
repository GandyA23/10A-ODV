using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    private bool playerSaw;
    private Transform playerTransform;
    private SphereCollider visionRange;

    // Start is called before the first frame update
    void Start()
    {
        visionRange = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerSaw);

        if (playerTransform == null)
            return;

        // B - A
        Vector3 vectorToPlayer = playerTransform.position - transform.position;

        float dotProduct = Vector3.Dot(transform.forward, vectorToPlayer);

        if (dotProduct > 0)
        {
            // Aumenta 1 unidad el rayo en altura para que no choque con el suelo
            Vector3 origin = transform.position + Vector3.up;

            // Verifica si el objeto en el cual colisiono, es un jugador
            if (Physics.Raycast(origin, vectorToPlayer, out RaycastHit hit, visionRange.radius))
            {
                if (hit.transform.tag == "Player")
                {
                    // Dibuja un rayo de color rojo en caso de que colisione con el jugador
                    Debug.DrawRay(origin, vectorToPlayer, Color.red);
                    playerSaw = true;
                }
                else
                {
                    // Dibuja un rayo de color blanco en caso de que colisione con un objeto que no sea el jugador
                    Debug.DrawRay(origin, vectorToPlayer, Color.white);
                    playerSaw = false;
                }
            }
        }
        else 
        {
            playerSaw = false;
        }

        Debug.Log(dotProduct);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica la etiqueta dle other si es un jugador
        if (other.tag == "Player")
        { 
            playerTransform = other.transform;
            playerSaw = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerTransform = null;
            playerSaw = false;
        }
    }
}
