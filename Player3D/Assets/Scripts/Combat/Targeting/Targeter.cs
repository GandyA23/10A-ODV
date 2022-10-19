using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class Targeter : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup cineTargetGroup;
    public List<Target> targets = new List<Target>();
    public Target CurrentTarget { get; private set; }

    /**
     * OnTriggerEnter y OnTriggerExit nos ayudará a detectar los cuerpos que entran y 
     * salen dentro del radio
     */
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto tiene un Target
        if (other.TryGetComponent<Target>(out Target target)) 
        {
            target.OnDestroyed += RemoveTarget;
            targets.Add(target);
        } 
    }

    private void RemoveTarget(Target target)
    {
        // Verifica que el target sea el mismo al current para eliminarlo del enfoque de la camara
        if (CurrentTarget == target)
            Cancel();

        // Se desuscribe en caso de que el objetivo haya sido destruido
        target.OnDestroyed -= RemoveTarget;
        targets.Remove(target);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Target>(out Target target))
            RemoveTarget(target);
    }

    public bool SelectTarget()
    {
        if (targets.Count == 0)
            return false;

        CurrentTarget = targets[0];


        // Agrega el CurrentTarget a la lista de objetivos para fijarlos en camara
        // Con weight = 1 y radius = 1
        cineTargetGroup.AddMember(CurrentTarget.transform, 1, 1);

        return true;
    }

    public void Cancel()
    {
        // Elimina al target al cuál vamos a fijar la camara
        if (CurrentTarget != null)
        { 
            cineTargetGroup.RemoveMember(CurrentTarget.transform);
            CurrentTarget = null;
        }
    }
}
