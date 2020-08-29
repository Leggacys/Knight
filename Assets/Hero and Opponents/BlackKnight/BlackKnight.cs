using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnight : Enemy,IHitit
{
    //Private Variables
    private Animator _anim;
    private float _time;
    private int _curentNumbersOfAttacks;
    //Public Variables
    public int frequncy;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(transform.position,Vector2.left,attackRange,enemyLayers))
        {
            _anim.SetBool("Walking", false);
                Attack();
        }
        else
        {
            _anim.SetBool("Walking", true);
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
    }


    private void Attack()
    {
        if(_time+TimeBetwenTheAtack<Time.time)
        {
            _anim.SetTrigger("Attack");
            _time = Time.time;
            _curentNumbersOfAttacks++;
        }
    }

    public void SupperAttack()
    {
        if(_curentNumbersOfAttacks>frequncy)
        {
            _anim.SetBool("SupperAttack", true);
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
        Instantiate(hitSound, transform.position, transform.rotation);
        health -= damage;
        if(health<=0)
        {
            _anim.SetTrigger("Dead");
            Instantiate(blod, transform.position, transform.rotation);
            DropCoin();
        }
    }

    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitPoint.position, attackRange, enemyLayers);
        enemies[0].GetComponent<IHititSolediers>().TakeDamage(damage);
    }

    public void DeadTrue()
    {
        Destroy(gameObject);
    }

    public void SupperAttackTouch()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitPoint.position, attackRange, enemyLayers);

        foreach (var item in enemies)
        {
            item.GetComponent<IHititSolediers>().TakeDamage(damage);
        }
        _anim.SetBool("SupperAttack", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPoint.position, radius);
    }

}
