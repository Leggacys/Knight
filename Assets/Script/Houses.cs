using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;

public class Houses : MonoBehaviour
{
    // Public Variable
    public float area;
    public float dimension;
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
        if (Math.Abs(_player.transform.position.x) - dimension > area)
        {
            Area(false);
        }
        else
        {
            Area(true);
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