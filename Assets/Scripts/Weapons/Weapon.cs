using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _prise;
    [SerializeField] private bool _isBuyed;
    [SerializeField] private Sprite _sprite;
    [SerializeField] protected Bullet Bullet;

    public int Price => _prise;
    public Sprite Sprite => _sprite;
    public bool IsBuyed => _isBuyed;

    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        _isBuyed = true;
    }
}
