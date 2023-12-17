using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour, IBarChanged
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private List<Transform> _transforms;
    [SerializeField] private Player _player;

    public event UnityAction AllEnemySpawn;
    public event UnityAction<int, int> BarChanged;

    private int _currentWaveNumber;
    private int _spawned;
    private Enemy _newEnemy;

    public bool SpawnEnd { get; private set; }


    private Wave _ñurrentWave
    {
        get { return _waves[_currentWaveNumber]; }
    }

    private void Awake()
    {
        _currentWaveNumber = 0;
    }

    private void Start()
    {
        if (_currentWaveNumber < _waves.Count && _currentWaveNumber >= 0)
        {
            StartCoroutine(Spawn());
        }
    }

    public void NextWave()
    {
        if (++_currentWaveNumber < _waves.Count)
        {
            StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        _spawned = 0;
        BarChanged.Invoke(_spawned, _ñurrentWave.Count);
        SpawnEnd = false;

        WaitForSeconds _waitForDelay = new WaitForSeconds(_ñurrentWave.Delay);

        for(int i = 0;  i < _ñurrentWave.Count; i++)
        {
            InstantiateEnemy(_ñurrentWave.Enemy);

            BarChanged.Invoke(++_spawned, _ñurrentWave.Count);

            yield return _waitForDelay;
        }

        SpawnEnd = true;
        AllEnemySpawn.Invoke();
    }

    private void InstantiateEnemy(Enemy enemy)
    {
        _newEnemy = Instantiate(enemy, _transforms[UnityEngine.Random.Range(0, _transforms.Count)].position, Quaternion.identity);
        _newEnemy.Init(_player);
        _newEnemy.Dying += GiveMoneyToPlayer;
    }

    private void GiveMoneyToPlayer(Enemy enemy)
    {
        _player.TakeMoney(enemy.Reward);
        enemy.Dying -= GiveMoneyToPlayer;
    }
}


[System.Serializable]
public class Wave
{
    public Enemy Enemy;
    public float Delay;
    public int Count;
}