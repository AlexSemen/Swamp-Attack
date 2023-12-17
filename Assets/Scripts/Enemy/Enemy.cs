using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private bool _isAttack;

    public event UnityAction<Enemy> Dying;
    private Player _target;

    public int Reward => _reward;

    public Player Target => _target;
    public bool IsAttack => _isAttack;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Dying.Invoke(this);
            Destroy(gameObject);
        }
    }

    public void Init(Player player)
    {
        _target = player;
    }
}
