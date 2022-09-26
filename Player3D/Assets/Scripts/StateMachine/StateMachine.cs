using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    private State currentState;

    /**
     * Realiza el cambio de estado
     **/
    public void SwitchState(State newState) 
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    // Update is called once per frame
    public void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }
}
