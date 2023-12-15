using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _distanceAttack;

    private float _lastAttackTime;
    private Animator _animator;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (_enemy.IsAttack == false)
        {
            _animator.SetTrigger(AnimatorEnemy.Triggers.Attack);
        }
    }

    public void DoDamage()
    {
        if (Vector2.Distance(transform.position, _target.transform.position) < _distanceAttack)
        {
            _target.TakeDamage(_damage);
        }
    }
}
