using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houses : MonoBehaviour,IBought
{
    // Public Variable
    public float areaMax;
    public float areaMin;
    public int price;
    public GameObject ornament;
    public GameObject civilian;
    

    //Private Variable
    private bool complete = false;
    private GameObject _player;
    private bool _bought = false;
    
    void Start()
    {
        
        _player=GameObject.FindGameObjectWithTag("Player");
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f);
    }

    public void Update()
    {
       if(_bought==false)
        if (_player.transform.position.x<areaMax&&_player.transform.position.x>areaMin)
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
            StartCoroutine( Alpha());
            civilian.SetActive(true);
        }
        else
        {
            Debug.Log("you are too por");
        }
    }
}