using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Enemy : MonoBehaviour
{
    //Public variable
    public float TimeBetwenTheAtack;
    public float distance;
    public float speed;
    public int health;
    public float radius;
    public LayerMask enemyLayers;
    public Transform hitPoint;
    public int damage;
    public GameObject sound;
    public GameObject hitSound;
    [HideInInspector]
    public GameObject _moneyTable;
    public int coinDrop;
    public GameObject blod;
    //Private variable
    [HideInInspector]
    public GameObject _player;

    virtual public void Start()
    {
        _moneyTable = GameObject.FindGameObjectWithTag("Coin");
        _player = GameObject.FindGameObjectWithTag("Player");
    }

   
    

   
}
