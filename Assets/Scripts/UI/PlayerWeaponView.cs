using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponView : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Button _nextWeaponButton;
    [SerializeField] Button _prevWeaponButton;
    [SerializeField] Image _imageWeapon;

    private void Start()
    {
        _imageWeapon.sprite = _player.Weapon.Sprite;
    }

    private void OnEnable()
    {
        _nextWeaponButton.onClick.AddListener(OnNextWeaponButtonClick);
        _prevWeaponButton.onClick.AddListener(OnPrevWeaponButtonClick); 
    }

    private void OnDisable()
    {
        _nextWeaponButton.onClick.RemoveListener(OnNextWeaponButtonClick);
        _prevWeaponButton.onClick.RemoveListener(OnPrevWeaponButtonClick);
    }

    public void OnNextWeaponButtonClick()
    {
        _player.NextWeapon();
        _imageWeapon.sprite = _player.Weapon.Sprite;
    }

    public void OnPrevWeaponButtonClick() 
    {
        _player.PrevWeapon();
        _imageWeapon.sprite = _player.Weapon.Sprite;
    }
}
