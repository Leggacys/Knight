using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy,IHitit
{

    //Private Variables
    private Animator _anim;
    private float _time;

  

    // Start is called before the first frame update
  public override  void Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
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

    public void DropCoin()
    {
        _moneyTable.GetComponent<CoinScript>().AddCoin(coinDrop);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(hitSound, transform.position, transform.rotation);
        _anim.SetTrigger("Hitit");
        if (health <= 0)
        {
            Instantiate(sound, transform.position, transform.rotation);
            DropCoin();
            _anim.SetTrigger("Death");
        }
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

    public void Death()
    {
        Destroy(gameObject);
    }
}
