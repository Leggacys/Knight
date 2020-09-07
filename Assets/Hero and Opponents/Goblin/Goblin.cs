using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin :Enemy,IHitit
{

    //Private Variables
    private Animator _anim;
    private float _time;
    //pUblic Variables
    public int moneyTake;
    

    public override void Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();

    }
    public void DropCoin()
    {
        _moneyTable.GetComponent<CoinScript>().AddCoin(coinDrop);
    }

    public void TakeDamage(int damage)
    {
        Instantiate(hitSound, transform.position, transform.rotation);
        health -= damage;
        _anim.SetTrigger("Hitit");
        if(health<=0)
        {
            DropCoin();
            _anim.SetTrigger("Death");
            Instantiate(sound, transform.position, transform.rotation);
        }
    }

    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitPoint.position, attackRange, enemyLayers);
        enemies[0].GetComponent<IHititSolediers>().TakeDamage(damage);
        if (enemies[0].tag == "Player")
            GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().AddCoin(-moneyTake);
    }


    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(transform.position,Vector2.left,attackRange,enemyLayers))
        {
            _anim.SetBool("Walk", false);
            Attack();
        }
        else
        {
            _anim.SetBool("Walk", true);
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
    }

    private void Attack()
    {
        if(_time+TimeBetwenTheAtack<Time.time)
        {
        _anim.SetTrigger("Attack");
            _time = Time.time;
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPoint.position, radius);
    }
}
