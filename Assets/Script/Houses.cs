using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houses : MonoBehaviour
{
    // Public Variable
    public float areaMax;
    public float areaMin;
    
    //Private Variable
    private bool complete = false;
    private GameObject _player;
    void Start()
    {
        _player=GameObject.FindGameObjectWithTag("Player");
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f);
    }

    public void Update()
    {
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
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }


    IEnumerator Alpha()
    {
        float alpha = 0.2f;
        while (alpha < 5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
            alpha += 0.2f;
            yield return new WaitForSeconds(0.5f);
        }
    }


}