using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    
    private Player _target;
    private State _currentState;
    private State _newState;

    public State Current => _currentState;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        if (_currentState == null)
        {
            Reset();
            return;
        }

        if(_currentState.TryGetNewState(out _newState))
        {
            Transit(_newState);
        }
    }

    private void Reset()
    {
        _target = GetComponent<Enemy>().Target;

        if (_firstState != null && _target != null)
        {
            _currentState = _firstState;
            _currentState.Enter(_target);
        }
    }

    private void Transit(State nexState)
    {
        if(_currentState != null)
        {
            _currentState.Exit();
        }

        if (nexState != null)
        {
            _currentState = nexState;
            _currentState.Enter(_target);
        }
    }
}
