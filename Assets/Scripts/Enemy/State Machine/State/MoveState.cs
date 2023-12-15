using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveState : State
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = Vector2.right * _speed;
        //_rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, _target.transform.position, _speed));
    }

    private void OnDisable()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }
}
