using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] Transform _shootPoint;
    [SerializeField] Weapon _weapon;
    [SerializeField] bool _isAttack;

    private Animator _animator;
    
    public int Money { get; private set; }

    private void Awake()
    {
        _isAttack = false;
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_isAttack == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetTrigger(AnimatorPlayer.Triggers.Shoot);
            }
        }
    }

    public void Shoot()
    {
        _weapon.Shoot(_shootPoint);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0) 
        { 
            Destroy(gameObject);
        }
    }

    private void OnEnemyDying(int reward)
    {
        Money += reward;
    }
}
