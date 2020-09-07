using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    //Public Variables
    public List<Enemy> enemies = new List<Enemy>();
    public List<float> time = new List<float>();
    public int numbersOfSpawnPoint;
    public Transform spawnPosition;
    //Private Variables
    private float _waitTime;

    public void Start()
    {
        StartCoroutine(SpawnStart());
    }

    IEnumerator SpawnStart()
    {
        do
        {
            Enemy radnomEnemy = enemies[Random.Range(0, enemies.Count)];
            Instantiate(radnomEnemy, spawnPosition.position, spawnPosition.rotation);
            _waitTime++;
            yield return null;
        } while (_waitTime < numbersOfSpawnPoint);
        _waitTime = 0;
        float randomTimeWait = time[Random.Range(0, time.Count)];
        yield return new WaitForSeconds(randomTimeWait);
    }

  
}
