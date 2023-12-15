using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private GameObject _targetIBarChanged;
    [SerializeField] private Slider _slider;

    private IBarChanged _target;

    private void Awake()
    {
        _target = _targetIBarChanged.GetComponent<IBarChanged>();
    }

    private void OnEnable()
    {
        if (_target != null)
        {
            _target.BarChanged += BarChanged;
        }
    }

    private void OnDisable()
    {
        if (_target != null)
        {
            _target.BarChanged -= BarChanged;
        }
    }

    private void BarChanged(int value, int maxValue)
    {
        _slider.maxValue = maxValue;
        _slider.value = value;
        
    }
}
