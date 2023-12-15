using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour, IBarChanged
{
    [SerializeField] int _health;
    [SerializeField] int _healthMax;
    [SerializeField] Transform _shootPoint;
    [SerializeField] Weapon _weapon;
    [SerializeField] bool _isAttack;

    private Animator _animator;

    public event UnityAction<int, int> BarChanged;

    public int Money { get; private set; }

    private void Awake()
    {
        _health = _healthMax;
        _isAttack = false;
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        BarChanged.Invoke(_health, _healthMax);
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

        BarChanged.Invoke(_health, _healthMax);

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
