using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss :MonoBehaviour ,IHitit
{
    //Public variable
    public float TimeBetwenTheAtack;
    public float speed;
    public int health;
    public float radius;
    public LayerMask enemyLayers;
    public Transform hitPoint;
    public int damage;
    public GameObject sound;
    public GameObject hitSound;
    public int coinDrop;
    public GameObject blod;
    public float attackRange;
    //Private Variables
    protected GameObject _moneyTable;
    protected Animator _anim;
    protected float _time;

    public virtual void Start()
    {
        _moneyTable = GameObject.FindGameObjectWithTag("Coin");
        _anim = GetComponent<Animator>();
    }

    public virtual void Update()
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

    protected void Attack()
    {
        if (_time + TimeBetwenTheAtack < Time.time)
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
       // Instantiate(hitSound, transform.position, transform.rotation);
        health -= damage;
        if (health <= 0)
        {
            _anim.SetTrigger("Death");
            DropCoin();
            Instantiate(sound, transform.position, transform.rotation);
            Instantiate(blod, transform.position, transform.rotation);
            
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

    private void Death()
    {
        Destroy(gameObject);
    }

    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPoint.position, radius);
    }
}
