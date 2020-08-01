using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheKnight : MonoBehaviour, IHititSolediers
{
    //Public Variables
    public LayerMask _enemyLayers;
    public float speed;
    public float distance;
    public float timeBetweenAttack;
    public float health;
    public Transform HitPoint;
    public int damage;
    public float attackRange;
    //Private Variables
    private Animator _anim;
    private float _time;
    
    void Start()
    {
        _anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(transform.position,Vector2.right,distance,_enemyLayers))
        {
            _anim.SetBool("Walk", false);
            if(_time+timeBetweenAttack<Time.time)
            {
            _anim.SetTrigger("Attack");
                _time = Time.time;
            }
        }
        else
        {
            _anim.SetBool("Walk", true);
            transform.position += new Vector3(speed,0,0) * Time.deltaTime;
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        _anim.SetTrigger("TakeHit");
        if(health<=0)
        {
            _anim.SetTrigger("Death");
            Destroy(gameObject, 0.9f);
        }
    }

    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(HitPoint.position, attackRange, _enemyLayers);
        foreach (var e in enemies)
        {
            e.GetComponent<IHitit>().TakeDamage(damage);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(HitPoint.position, attackRange);
    }

}
