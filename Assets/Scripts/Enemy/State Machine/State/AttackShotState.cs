using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]
public class AttackShotState : State
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] EnemyBullet _bullet;

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

    public void Attack()
    {
        if (_enemy.IsAttack == false)
        {
            _animator.SetTrigger(AnimatorEnemy.Triggers.Attack);
        }
    }

    public void Shot()
    {
        Instantiate(_bullet, _shootPoint);
    }
}
