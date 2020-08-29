using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyes :Enemy,IHitit
{

    //Private variables
    private Animator _anim;
    private float time;
   

    // Start is called before the first frame update
    public override void  Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(transform.position,Vector2.left,attackRange,enemyLayers))
        {
            Attack();
        }
        else
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
    }


    private void Attack()
    {
        if(time+TimeBetwenTheAtack<Time.time)
        {
            _anim.SetTrigger("Attack");
            time = Time.time;
        }
    }

    public IEnumerator Dead()
    {
        throw new System.NotImplementedException();
    }

    public void DropCoin()
    {
        _moneyTable.GetComponent<CoinScript>().AddCoin(coinDrop);
    }

    public void TakeDamage(int damage)
    {
        _anim.SetTrigger("Hitit");
        health -= damage;
        Instantiate(hitSound, transform.position, transform.rotation);
        if (health<=0)
        {
            _anim.SetTrigger("Dead");
            DropCoin();
            Instantiate(sound, transform.position, transform.rotation);
        }
    }

    public void DeathTrue()
    {
        Destroy(gameObject);
    }

    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitPoint.position, radius, enemyLayers);
        enemies[0].GetComponent<IHititSolediers>().TakeDamage(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPoint.position, radius);
    }
}
