using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    //Public Variables
    [System.Serializable]
    public class Wave
    {
    public GameObject[] enemies;
    public int count;
    public float timeBetwenTheSpawnEnemies;

    }
    public Transform spawnPoint;
    public Wave[] waves;
    public GameObject _player;

    public float timeBetwenTheSpawn;
    //Private Variables
    private int _curentWaveIndex;
    private Wave _wave;
    private bool _finishgWave = true;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            if (_curentWaveIndex < waves.Length) 
            {
                if (_finishgWave == true)
                {
                    _finishgWave = !_finishgWave;
                    StartCoroutine(StartNextWave(_curentWaveIndex));
                    _curentWaveIndex++;
                }
            }
        }
    }

    public IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetwenTheSpawn);
        StartCoroutine(StartWave(index));

    }

    public IEnumerator StartWave(int index)
    {
        _wave = waves[index];
        for (int i = 0; i < _wave.count; i++)
        {
            GameObject randomEnemies = _wave.enemies[Random.Range(0, _wave.enemies.Length)];
            Instantiate(randomEnemies, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(_wave.timeBetwenTheSpawnEnemies);
        }

        _finishgWave = !_finishgWave;
    }
}
