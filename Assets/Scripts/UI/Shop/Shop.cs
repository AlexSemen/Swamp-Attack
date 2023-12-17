using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private WeaponView _prefab;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _container;
    [SerializeField] private TMP_Text _textManey;

    private WeaponView _newItem;

    private void Start()
    {
        foreach (var weapon in _weapons)
        {
            AddItem(weapon);
        }

        _textManey.text = _player.Money.ToString();
    }

    private void OnEnable()
    {
        _textManey.text = _player.Money.ToString();
    }

    public void AddItem(Weapon weapon)
    {
        _newItem = Instantiate(_prefab, _container.transform);
        _newItem.Render(weapon);
        _newItem.SetShop(this);
    }

    public bool TryBuyWeapon(Weapon weapon)
    {
        if (_player != null && _player.TryGiveMoney(weapon.Price))
        {
            weapon.Buy();

            _textManey.text = _player.Money.ToString();
            
            return true;
        }
        else
        {
            return false;
        }
    }
}
