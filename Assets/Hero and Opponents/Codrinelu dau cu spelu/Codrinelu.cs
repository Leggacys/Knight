using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codrinelu : MonoBehaviour
{
    //Private Variables
    private Animator _anim;
    private bool _finish=true;
    private float _time;
    //Public Variables
    public LayerMask layers;
    public Transform aim;
    public GameObject proiectiles;
    public float timeBeetwenAtack;


    void Start()
    {
        _anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(transform.position,transform.right,layers))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (_finish&&_time+timeBeetwenAtack<Time.time)
        {
            _anim.SetTrigger("FireBall");
            _finish = !_finish;
            _time = Time.time;
        }
    }

    public void ChangeSttaus()
    {
        _finish = !_finish;
    }

    public void FireBall()
    {
        Instantiate(proiectiles, aim.position, Quaternion.Euler(0, 0, 90));
    }
}
