using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngineInternal;

public class Kong : MonoBehaviour, IHititSolediers
{
    //Private Variable
    private Rigidbody2D _body;
    private Animator _anim;
    private bool _fight = false;
    private RaycastHit2D _hit;
    private float time;
    private float _nr = 0;
    //Public Variables
    public int health;
    public float atackRange;
    public LayerMask enemyLayers;
    public Transform HitPoint;
    public float speed;
    public LayerMask layers;
    public float lenght;
    public float jumpforce;
    public float floatHeight;
    public int damage;
    public float timeBetweenAttack;
    public float radius;
    public float _frequency;
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        Debug.DrawRay(new Vector2(transform.position.x + 1, transform.position.y), Vector2.right * 0.7f);
        if (Physics2D.Raycast(transform.position, Vector2.right, lenght, layers))
        {
            if (timeBetweenAttack + time < Time.time)
            {
                Fight();
            }
        }
        else
        {
            if(!_fight)
            Walk();
        }
    }


    private void Fight()
    {
        _fight = true;
        _anim.SetBool("Walk", false);
        _hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.7f, layers);
            MaleAttack();
    }

    
    private void MaleAttack()
    {
        _nr++;
        if (_nr == _frequency)
        {
            SuperAttack();
            _nr = 0;
        }
        else
        {
            _anim.SetTrigger("Kik");
        }
        
            time = Time.time;
        _fight = false;
        
    }

    private void SuperAttack()
    {
        _anim.SetTrigger("Punch");
    }
    private void Walk()
    {
        _anim.SetBool("Walk", true);
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
    }

  

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(HitPoint.position, atackRange);
    }


    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(HitPoint.position, atackRange, enemyLayers);
        if(enemies.Length!=0)
        enemies[0].GetComponent<IHitit>().TakeDamage(damage);
    }

    public void Touchedsuper()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayers);

        foreach (var item in enemies)
        {
            item.GetComponent<IHitit>().TakeDamage(damage);
            item.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 4f, ForceMode2D.Impulse);
        }
    }

    public void TakeDamage(int damage)
    {
        _anim.SetTrigger("Hitit");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

   
}
