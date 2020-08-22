using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{   
    //Public Variable
    [SerializeField]
    public GameObject[] movePoint;
    public float speed;
    public float timeToWait;
    //Private Variable
    private Animator _anim;
    private GameObject _randomPozition;
    private bool _reachPoint = false;
    private float InitialTime;
    private bool _facingRight = true;


    void Start()
    {
         _randomPozition = movePoint[Random.Range(0, movePoint.Length)];
        _anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_reachPoint==false)
        {FacingCorrectly();
            if (Vector2.Distance(transform.position, _randomPozition.transform.position) > 0.5f)
            { _anim.SetBool("Walk",true);
                transform.position = Vector2.MoveTowards(
                transform.position, _randomPozition.transform.position,
                speed * Time.deltaTime);
                InitialTime = Time.time;
            }
            else
            {
                _reachPoint = true;
            }
        }
        else {
            _anim.SetBool("Walk", false);
            if (InitialTime+timeToWait<Time.time)
            {
                _randomPozition = movePoint[Random.Range(0, movePoint.Length)];
                _reachPoint = false;
            }
        }
    }

    void FacingCorrectly()
    {
        if(transform.position.x<_randomPozition.transform.position.x && !_facingRight||
           transform.position.x>_randomPozition.transform.position.x && _facingRight)
        {
            _facingRight = !_facingRight;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

  
}
