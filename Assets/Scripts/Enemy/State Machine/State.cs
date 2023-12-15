using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
   [SerializeField] private List<Transition> _transitions = new List<Transition>();

    protected Player _target;

    public void Enter(Player target)
    {
        if(enabled == false)
        {
            _target = target;
            enabled = true;

            foreach(var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(_target);
            }
        }
    }

    public void Exit()
    {
        if(enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public bool TryGetNewState(out State newState)
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                newState = transition.TargetState;
                return true;
            }
        }

        newState = null;
        return false;
    }
}
