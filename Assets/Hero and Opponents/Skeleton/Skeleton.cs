using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Skeleton : Enemy,IHitit
{
    //Public variable
    
    //Private variable
    private Animator _anim;
    private bool _finishAtack=true;
    public override void Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
     void Update()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) > distance)
        {
            _anim.SetBool("Walk", true);
            transform.position = Vector2.MoveTowards(transform.position,_player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            _anim.SetBool("Walk", false);
            if(_finishAtack==true)
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

    public void TakeDamage(int damage)
    {
        _anim.SetTrigger("Hitit");
        health -= damage;
        if(health<=0)
        {
            _anim.SetTrigger("Dead");
            
        }
    }

    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitPoint.position, radius, enemyLayers);
         foreach(var e in enemies)
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
