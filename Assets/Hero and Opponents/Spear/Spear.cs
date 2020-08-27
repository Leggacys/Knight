using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Enemy,IHitit
{
    //Private variables
    private float time;
    private Animator _anim;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(transform.position,Vector2.left,distance,enemyLayers))
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

    public void Attack()
    {
        if(time+TimeBetwenTheAtack<Time.time)
        {
            _anim.SetTrigger("Attack");
            time = Time.time;
        }
    }

    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitPoint.position, radius, enemyLayers);
        enemies[0].GetComponent<IHititSolediers>().TakeDamage(damage);
    }


    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPoint.position, radius);
    }

    public void TakeDamage(int damage)
    {
        _anim.SetTrigger("Hitit");
        Instantiate(hitSound, transform.position, transform.rotation);
        health -= damage;
        if(health<=0)
        {
            DropCoin();
            Instantiate(sound, transform.position, transform.rotation);
            Instantiate(blod, transform.position, transform.rotation);
            _anim.SetTrigger("Dead");
            Destroy(gameObject, 0.7f);
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
}
