using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Skeleton : Enemy
{

    //Private variable
    private Animator _anim;
    public override void Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
     void Update()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) > distance)
        {
            _anim.SetBool("Walk", true);
            transform.position = Vector2.MoveTowards(transform.position,_player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            _anim.SetBool("Walk", false);
        }    
    }
}
