using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    //Private variable
    private GameObject _player;

    private bool _facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.transform.position.x > transform.position.x && _facingRight == false ||
            _player.transform.position.x < transform.position.x && _facingRight == true)
        {
            _facingRight = !_facingRight;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
