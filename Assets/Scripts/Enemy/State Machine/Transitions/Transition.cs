using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] State _targetState;

    public State TargetState => _targetState;

    public bool NeedTransit {  get; protected set; }

    public Player Target { get; private set; }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
