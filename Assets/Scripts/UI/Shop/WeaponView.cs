using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textName;
    [SerializeField] private TMP_Text _textPrice;
    [SerializeField] private Image _image;
    [SerializeField] private Button _sellButton;

    private Weapon _weapon;
    private Shop _shop;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _textName.text = weapon.name;
        _textPrice.text = weapon.Price.ToString();
        _image.sprite = weapon.Sprite;

        if (weapon.IsBuyed)
        {
            _sellButton.interactable = false;
        }
    }

    public void SetShop(Shop shop)
    {
        _shop = shop;
    }

    private void OnSellButtonClick()
    {
        if(_shop != null && _shop.TryBuyWeapon(_weapon)) 
        {
            Render(_weapon);
        }
    }
}
