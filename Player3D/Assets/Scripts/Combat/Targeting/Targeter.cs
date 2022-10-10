using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public List<Target> targets = new List<Target>();

    /**
     * OnTriggerEnter y OnTriggerExit nos ayudará a detectar los cuerpos que entran y 
     * salen dentro del radio
     */

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto tiene un Target
        if (other.TryGetComponent<Target>(out Target target)) 
            targets.Add(target);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Target>(out Target target)) 
        {
            
        }
    }
}
