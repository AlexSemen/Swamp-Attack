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
    [SerializeField] List<Weapon> _weapons;
    [SerializeField] bool _isAttack;

    private Animator _animator;
    private int _weaponNumber;
    public Weapon Weapon { get; private set; }

    public event UnityAction<int, int> BarChanged;

    public int Money { get; private set; }

    private void Awake()
    {
        Money = 500;
        _health = _healthMax;
        _isAttack = false;
        _animator = GetComponent<Animator>();
        SetWeapon(0);
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
        Weapon.Shoot(_shootPoint);
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

    public void TakeMoney(int money)
    {
        Money += money;
    }

    public bool TryGiveMoney(int money)
    {
        if (Money >= money)
        {
            Money -= money;

            return true;
        }
        else
        {
            return false;
        }
    }

    public void NextWeapon()
    {
        if(_weaponNumber < _weapons.Count - 1)
        {
            SetWeapon(++_weaponNumber);
        }
        else
        {
            SetWeapon(0);
        }
    }

    public void PrevWeapon()
    {
        if (_weaponNumber > 0)
        {
            SetWeapon(--_weaponNumber);
        }
        else
        {
            SetWeapon(_weapons.Count - 1);
        }
    }

    private void SetWeapon(int weaponNumber)
    {
        if (Weapon != null)
        {
            _animator.SetBool(Weapon.boolParameterAnimator, false);
        }

        _weaponNumber = weaponNumber;
        Weapon = _weapons[weaponNumber];

        _animator.SetBool(Weapon.boolParameterAnimator, true);
    }

    public void AddWeapon(Weapon weapon)
    {
        _weapons.Add(weapon);
    }
}
