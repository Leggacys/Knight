using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartialArtist : Soldier,IHititSolediers
{
    //Private Variables
    private Animator _anim;
    private Rigidbody2D _rb;
    private float time;
    private int curentAttackNumbers;
    //Public Variables
    public int frequency;


    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(transform.position,Vector2.right,lenght,enemyLayers))
            {
               _anim.SetBool("Walk", false);
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
        if(time+timeBetweenAttack<Time.time)
        {
        _anim.SetTrigger("Attack");
            time = Time.time;
            curentAttackNumbers++;
        }
    }

    public void SuperAttack()
    {
        if(curentAttackNumbers>=frequency)
        {
            _anim.SetBool("SupperAttack",true);
            curentAttackNumbers = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        _anim.SetTrigger("Hitit");
        health -= damage;
        if(health<=0)
        {
            _anim.SetTrigger("Death");
            Destroy(gameObject, 0.7f);
        }
    }
    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitpoint.transform.position, lenght, enemyLayers);
        if (enemies.Length != 0)
            enemies[0].GetComponent<IHitit>().TakeDamage(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitpoint.transform.position,radius);
    }

    public void Touchedsuper()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayers);

        foreach (var item in enemies)
        {
            item.GetComponent<IHitit>().TakeDamage(damage);
        }

        _anim.SetBool("SupperAttack", false);
    }
}
