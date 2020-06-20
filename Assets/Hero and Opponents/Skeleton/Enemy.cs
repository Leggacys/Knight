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
    //Private variable
    [HideInInspector]
    public GameObject _player;
    private Animator _anim;
   virtual public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

   
    

   
}
