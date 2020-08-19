using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Skeleton : Enemy,IHitit
{
    //Public variable
    public Player player;
    
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
        if (_player!=null)
        {

            if (!Physics2D.Raycast(transform.position, Vector2.left, attackRange, enemyLayers))
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
        Instantiate(hitSound, transform.position, transform.rotation);
        health -= damage;
        if(health<=0)
        {
            StartCoroutine(Dead());
            Instantiate(blod, transform.position, transform.rotation);
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

    public IEnumerator Dead()
    {
        DropCoin();
        _anim.SetTrigger("Dead");
        Instantiate(sound, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }

    public void DropCoin()
    {
       _moneyTable.GetComponent<CoinScript>().AddCoin(coinDrop);
    }
}
