using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/New Weapon", order = 51)]
public class Weapon : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Bullet _bullet;

    public void Shoot(Transform shootPoint)
    {
        Instantiate(_bullet, shootPoint);
    }
}
