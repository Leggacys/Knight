using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Public Variable
    public Joystick joystick;
    public float speed;
    public Button atack;
    public LayerMask enemyLayers;
    public Transform HitPoint;
    public float atackRange;
    public int damage;
    public int health;
    public GameObject transferPanel;
    public GameObject sound;
    public GameObject hurtSound;
    //Private Variable
    private Animator _anim;
    private bool _facingRight = true;
    private Rigidbody2D _rb;
    private int _press = 0;
    private bool _moving = false;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Scale();
    }


    private void Move()
    { 
        if(joystick.Horizontal!=0)
        {
        _rb.velocity = new Vector3(joystick.Horizontal * speed,0, joystick.Vertical*speed);
            _anim.SetBool("Run", true);
            sound.SetActive(true);
        }
        else
        {
            _anim.SetBool("Run", false);
            sound.SetActive(false);
        }
    }

    private void Scale()
    {
        if(joystick.Horizontal>0&&!_facingRight||joystick.Horizontal<0&&_facingRight)
        {
            _facingRight = !_facingRight;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public void AtackBegin()
    {
        _press++;
        if (_press == 2)
            Atack2();
        else
        Atack1();
    }

   public void Atack1()
    {
   
        _anim.SetTrigger("Atack");
        Touched();
    }

    public void Interactable()
    {
        atack.interactable = !atack.interactable;
    }

    public void ChangeBuutonStatus()
    {
        if (atack.interactable == false)
            atack.interactable =!atack.interactable;
    }

    public void Atack2()
    {
        Interactable();
        _press = 0;
        Touched();
        _anim.SetTrigger("Atack2");

    }

    public void Make0()
    {
        _press = 0;
    }

    public void Touched()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(HitPoint.position, atackRange, enemyLayers);
        foreach(var e in enemies)
        {
            e.GetComponent<IHitit>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(HitPoint.position, atackRange);
    }

    public void TakeDamage(int damage)
    {
        _anim.SetTrigger("Hit");
        Instantiate(hurtSound, transform.position, transform.rotation);
        health -= damage;
        if(health<=0)
        {
            StartCoroutine(Death());
        }
    }

     IEnumerator Death()
    {
        _anim.SetTrigger("Death");
        transferPanel.GetComponent<TransferPanel>().LoadScene(1);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);

    }

    
}
