using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BigSkeleton : Enemy,IHitit
{
    //Private variables
    private Animator _anim;
    private float _time; 

  

    // Start is called before the first frame update
   public override void Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(
            new Vector2(transform.position.x
            ,transform.position.y-1.45f),Vector2.left,attackRange,enemyLayers))
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

    public void DropCoin()
    {
        _moneyTable.GetComponent<CoinScript>().AddCoin(coinDrop);
    }

    public void Attack()
    {
        if (_time + TimeBetwenTheAtack < Time.time)
        {
        _anim.SetTrigger("Attack");
            _time = Time.time;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(hitSound, transform.position, transform.rotation);
        if (health <= 0)
        {
            DropCoin();
            Instantiate(sound, transform.position, transform.rotation);
            _anim.SetTrigger("Dead");
        }
    }

    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitPoint.position, radius, enemyLayers);
        foreach (var item in enemies)
        {
            item.GetComponent<IHititSolediers>().TakeDamage(damage);
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
