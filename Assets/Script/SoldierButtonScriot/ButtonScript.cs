using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject soldier;
    private Transform _spawnPoint;
    public float time;
    public int money;

    public void Start()
    {
        _spawnPoint = GameObject.FindGameObjectWithTag("SoldierSpawnPoint").transform;
    }

    public void SpawnSoldier()
    {
        if (GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().CoinAmount(money))
        {
            Instantiate(soldier, _spawnPoint.transform.position, _spawnPoint.rotation);
            StartCoroutine(Active());
        }
    }

    IEnumerator Active()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        gameObject.GetComponent<Button>().interactable=false;
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1,1);
        gameObject.GetComponent<Button>().interactable = true ;
    }    
    


}
