﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
    //Private variable
   private  Animator _anim;
   private bool _finishAtack = true;


   public override void  Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,_player.transform.position)>distance)
        {
            _anim.SetBool("Walk", true);
            transform.position= Vector2.MoveTowards(transform.position, _player.transform.position,speed*Time.deltaTime);
        }
        else
        {
            _anim.SetBool("Walk", false);
            if (_finishAtack == true)
            {
                StartCoroutine(Atack1());
                _finishAtack = false;
            }
        }
    }
    IEnumerator Atack1()
    {
        _anim.SetTrigger("Atack1");
        Touched();
        yield return new WaitForSeconds(TimeBetwenTheAtack);
        _finishAtack = true;

    }

    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitPoint.position, radius, enemyLayers);
        foreach (var e in enemies)
        {
            e.GetComponent<Player>().TakeDamage(damage);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPoint.position, radius);
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
