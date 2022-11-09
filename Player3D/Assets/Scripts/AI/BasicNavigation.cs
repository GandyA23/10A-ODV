using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicNavigation : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    protected NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Sigue al jugador dependiendo la posición del jugador
        navMeshAgent.destination = playerTransform.position;
    }
}
