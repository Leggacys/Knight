using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    //Public Varoables
    public float radius;
    public float speed;
    public LayerMask layers;
    public int damage;
    //Private Variables
    private Animator _anim;
    

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"||collision.tag=="Soldier")
        {
            _anim.SetTrigger("Destroy");
            Destroy(gameObject, 0.7f);
        }
    }

  private void Toch()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, layers);
        foreach (var item in enemies)
        {
            item.GetComponent<IHititSolediers>().TakeDamage(damage);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
