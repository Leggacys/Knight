using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngineInternal;

public class Kong : MonoBehaviour, IHititSolediers
{
    //Private Variable
    private Rigidbody2D _body;
    private Animator _anim;
    private bool _finishingJump = true;
    private bool _fight = false;
    private RaycastHit2D _hit;
    private float time;
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
         _hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.7f,layers);
        if(_hit.collider !=null)
        {
            MaleAttack();      
        }
        else
        {
            JumpAttack();
        }
    }

    private void JumpAttack()
    {
        
        if (_finishingJump == true)
        {
            _finishingJump = !_finishingJump;
            StartCoroutine(Jump());
        }
    }
    private void MaleAttack()
    {
            _anim.SetTrigger("Kik");
            time = Time.time;
        _fight = false;
    }
    private void Walk()
    {
        _anim.SetBool("Walk", true);
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
    }

   IEnumerator Jump()
    {
        
        _anim.SetTrigger("Distance");
        _body.velocity = Vector2.up * jumpforce;
        yield return new WaitForSeconds(0.4f);
        _anim.SetTrigger("NearEnemies");
        _body.velocity = Vector2.right * (jumpforce-2);
        yield return new WaitForSeconds(2f);
        _finishingJump = !_finishingJump;
        _fight = false;
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(HitPoint.position, atackRange);
    }


    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(HitPoint.position, atackRange, enemyLayers);
        foreach (var e in enemies)
        {
            e.GetComponent<IHitit>().TakeDamage(damage);
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
