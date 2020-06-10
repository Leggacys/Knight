using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Public Variable
    public Joystick joystick;
    public float speed;
    public Button atack;
   
    //Private Variable
    private Animator _anim;
    private bool _facingRight = true;
    private Rigidbody2D _rb;
    private int _press = 0;
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
        }
        else
        {
            _anim.SetBool("Run", false);
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
    }

    public void Interactable()
    {
        atack.interactable = !atack.interactable;
    }

    public void Atack2()
    {
        Interactable();
        _press = 0;
        _anim.SetTrigger("Atack2");

    }

    public void Make0()
    {
        _press = 0;
    }
}
