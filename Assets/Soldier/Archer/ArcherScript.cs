using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArcherScript : Soldier,IHititSolediers
{

    //Private Variables
    private Animator _anim;
    private float time=0;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y-0.5f), Vector2.right, lenght,enemyLayers))
        {
            Attack();
        }
        else
        {
          _anim.SetBool("Walk", true);
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
    
    private void Attack()
    {
        _anim.SetBool("Walk", false);
        if (time+timeBetweenAttack<Time.time)
        {
            time = Time.time;
            _anim.SetTrigger("Attack");
        }
        
    }

    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitpoint.transform.position, radius, enemyLayers);
        if (enemies.Length != 0)
            enemies[0].GetComponent<IHitit>().TakeDamage(damage);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitpoint.transform.position, radius);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        _anim.SetTrigger("Hitit");
        if(health<=0)
        {
            _anim.SetTrigger("Dead");
            Destroy(gameObject, 0.5f);
        }
    }
}
