using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    //Public Variables
    public List<Enemy> enemies = new List<Enemy>();
    public List<float> time = new List<float>();
    public List<int> numbersOfMonsters = new List<int>();
    public int numbersOfSpawnMonsters;
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
            yield return new WaitForSeconds(0.2f);
            Instantiate(radnomEnemy, spawnPosition.position, spawnPosition.rotation);
            _waitTime++;
            yield return null;
        } while (_waitTime < numbersOfSpawnMonsters);
        _waitTime = 0;
        numbersOfSpawnMonsters = numbersOfMonsters[Random.Range(0, numbersOfMonsters.Count)];
        float randomTimeWait = time[Random.Range(0, time.Count)];
        yield return new WaitForSeconds(randomTimeWait);
        StartCoroutine(SpawnStart());
    }

}
