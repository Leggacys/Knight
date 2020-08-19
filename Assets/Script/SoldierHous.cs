using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoldierHous : MonoBehaviour,IBought
{
    // Public Variable
    public float areaMax;
    public float areaMin;
    public int price;
    public GameObject ornament;
    public GameObject soldier;
    public GameObject sound;
    public GameObject Word;

    //Private Variable
    private GameObject _player;
    private bool _bought = false;


    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (!CazarmManager.instance.Exist(gameObject.name))
            CazarmManager.instance.Memorize(gameObject.name, _bought);
        _bought = CazarmManager.instance.ReturnValue(gameObject.name);
        if (_bought == false)            
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f);
        else
        {
            soldier.SetActive(true);
            ornament.SetActive(true);
        }
       
    }
    public void Update()
    {
        if (_bought == false)
        {
            HouseStatus();
        }
    }
    public void EnoughtMoney()
    {
        if (GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().CoinAmount(price) && !_bought)
        {
            SaveSystem.SaveHouses();
            Instantiate(Word, new Vector3(transform.position.x,
                transform.position.y + 0.4f
                , transform.position.z), transform.rotation);
           CazarmManager.instance.Change(gameObject.name, true);
            StartCoroutine(Alpha());
            soldier.SetActive(true);
            Instantiate(sound, transform.position, transform.rotation);
        }
        else
        {
            Debug.Log("you are too por");
        }
    }
    public void HouseStatus()
    {
        if (_player.transform.position.x < areaMax && _player.transform.position.x > areaMin)
        {
            Area(true);
        }
        else
        {
            Area(false);
        }
    }
    public void Area(bool position)
    {

        if (position)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
            ornament.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
        }
        else
        {
            ornament.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }

   
    IEnumerator Alpha()
    {

        _bought = true;
        float alpha = 0.2f;
        while (alpha < 10f)
        {

            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
            ornament.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
            alpha += 0.2f;
            yield return new WaitForSeconds(0.5f);
        }

    }

}
