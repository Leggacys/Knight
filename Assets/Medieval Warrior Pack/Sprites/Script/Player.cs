using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IHititSolediers
{
    //Public Variable
    public Joystick joystick;
    public float speed;
    public Button atack;
    public LayerMask enemyLayers;
    public Transform HitPoint;
    public float atackRange;
    public float damage;
    public float health;
    public GameObject transferPanel;
    public GameObject sound;
    public GameObject hurtSound;
    public CoinScript coins;
    public float def ;
    //Private Variable
    private Animator _anim;
    private bool _facingRight = true;
    private Rigidbody2D _rb;
    private int _press = 0;
    private Collider2D _coll;
    private bool _attack = false;
    void Start()
    {
       
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
       LoadNewStatus();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Scale();
    }


    private void Move()
    { 
        if(joystick.Horizontal!=0&&!_attack)
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
        _attack = true;
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
        enemies[0].GetComponent<IHitit>().TakeDamage((int)damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(HitPoint.position, atackRange);
    }

    public void TakeDamage(int damage)
    {
        _anim.SetTrigger("Hit");
        Instantiate(hurtSound, transform.position, transform.rotation);
        health -=( damage-def);
        if(health<=0)
        {
            StartCoroutine(Death());
        }
    }

     IEnumerator Death()
    {
        _anim.SetTrigger("Death");
        transferPanel.GetComponent<TransferPanel>().LoadScene(0);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);

    }
    void  OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "House"||collision.tag=="SoldierHous")
            _coll = collision;
        
        
    }

    public void Buy()
     {
        if(_coll.tag=="House")
        _coll.GetComponent<Houses>().EnoughtMoney();
        if (_coll.tag == "SoldierHous")
            _coll.GetComponent<SoldierHous>().EnoughtMoney();
     }

   
    public void ChangeAttack()
    {
        if(_attack==true)
            _attack = !_attack;
    }

    private void LoadNewStatus()
    {
        Dictionary<string, float> _newStatus = new Dictionary<string, float>(StatusManager.instance.LoadStatusInGame());
        health += _newStatus["HP"];
        speed += _newStatus["Speed"];
        if (speed > 3)
            speed = 3;
        def += _newStatus["Def"];
        damage += _newStatus["Attack"];
    }
}
