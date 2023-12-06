using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public WaveObject[] _waves;

    public int _currentWave;

    public bool _canSpawnWaves;

    private void Awake()
    {
        instance = this;

    }
    public float _timeToNextWave;
    void Start()
    {
        _timeToNextWave = _waves[0]._timeToSpawn;
    }
    void Update()
    {
        if(_canSpawnWaves)
        {
            _timeToNextWave -= Time.deltaTime;
            if (_timeToNextWave <= 0)
            {
                Instantiate(_waves[_currentWave]._theWave, transform.position, transform.rotation);

                if (_currentWave < _waves.Length - 1)
                {
                    _currentWave++;

                    _timeToNextWave = _waves[_currentWave]._timeToSpawn;
                }
                else
                {
                    _canSpawnWaves = false;
                }
            }
        }        
    }
    public void ContinueSpawning()
    {
        if (_currentWave < _waves.Length - 1 && _timeToNextWave > 0)
        {
            _canSpawnWaves = true;
        }
    }
}

[System.Serializable]
public class WaveObject
{
    public float _timeToSpawn;
    public EnemyWave _theWave;
}
