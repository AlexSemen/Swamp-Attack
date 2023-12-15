using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private List<Spawner> _spawners;
    [SerializeField] private Button _button;

    private bool _needActiveButton;

    private void OnEnable()
    {
        foreach (var spawner in _spawners)
        {
            spawner.AllEnemySpawn += OnAllEnemySpawn;
        }

        _button.onClick.AddListener(OnClickButton);
    }

    private void OnDisable()
    {
        foreach (var spawner in _spawners)
        {
            spawner.AllEnemySpawn -= OnAllEnemySpawn;
        }

        _button.onClick.RemoveListener(OnClickButton);
    }

    private void OnAllEnemySpawn()
    {
        _needActiveButton = true;

        foreach (var spawner in _spawners)
        {
            if(spawner.SpawnEnd == false)
            {
                _needActiveButton = false;
            }
        }

        if (_needActiveButton)
        {
            _button.gameObject.SetActive(true);
        }
    }

    private void OnClickButton()
    {
        foreach (var spawner in _spawners)
        {
            spawner.NextWave();
        }

        _button.gameObject.SetActive(false);
    }
}
