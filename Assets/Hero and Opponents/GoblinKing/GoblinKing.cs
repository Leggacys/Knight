using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKing : Boss
{

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (Physics2D.Raycast(new Vector2(
            transform.position.x,
            transform.position.y-1f), Vector2.left, attackRange, enemyLayers))
        {
            _anim.SetBool("Walk", false);
            if (_time + TimeBetwenTheAtack < Time.time)
            {
                Attack();
                _time = Time.time;
            }
        }
        else
        {
            _anim.SetBool("Walk", true);
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
    }

}
