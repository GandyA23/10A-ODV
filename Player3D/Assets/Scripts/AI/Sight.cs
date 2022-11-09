using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    private bool playerSaw;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
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

        playerSaw = dotProduct > 0;

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
