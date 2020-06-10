using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Enemy : MonoBehaviour
{
    //Public variable
    public float distance;
    public float speed;
    //Private variable
    [HideInInspector]
    public GameObject _player;
   virtual public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    
   
}
