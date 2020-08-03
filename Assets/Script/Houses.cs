using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Houses : MonoBehaviour,IBought
{
    // Public Variable
    public float areaMax;
    public float areaMin;
    public int price;
    public GameObject ornament;
    public GameObject civilian;
    public GameObject sound;
    public GameObject Word;

    //Private Variable
    private GameObject _player;
    private bool _bought = false;
    

    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if(!HousesManager.instance.Exist(gameObject.name))
        HousesManager.instance.Memorize(_bought,gameObject.name);
       _bought = HousesManager.instance.ReturnValue(gameObject.name);
       if (_bought == false)
           GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f);
        
    }

    public void Update()
    {
        if (_bought == false)
        { 
            HouseStatus();
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
            ornament.GetComponent<SpriteRenderer>().color=new Color(1,1,1,alpha);
            alpha += 0.2f;
            yield return new WaitForSeconds(0.5f);
        }

    }

    public void EnoughtMoney()
    {
        if (GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().CoinAmount(price) && !_bought)
        {
            Instantiate(Word, new Vector3(transform.position.x,
                transform.position.y+0.4f
                ,transform.position.z), transform.rotation);
            HousesManager.instance.Change(gameObject.name,true);
            StartCoroutine( Alpha());
            civilian.SetActive(true);
            Instantiate(sound, transform.position, transform.rotation);
        }
        else
        {
            Debug.Log("you are too por");
        }
    }
}