using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul :Enemy
{
    //Public Varoables
    public float radius;
    public float speed;
    public LayerMask layers;
    public int damage;
    public float attackRange;
    //Private Variables
    private Animator _anim;
    

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(transform.position,Vector2.left,attackRange,layers))
        {
            _anim.SetTrigger("Destroy");
        }
        else
        {
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
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
