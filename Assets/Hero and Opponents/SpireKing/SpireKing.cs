using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpireKing : Boss
{
   

    // Update is called once per frame
    public override void Update()
    {
        if(Physics2D.Raycast(hitPoint.position,Vector2.left,attackRange,enemyLayers))
        {
            _anim.SetBool("Walk", false);
                Attack();
        }
        else
        {
            _anim.SetBool("Walk", true);
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
    }
}
