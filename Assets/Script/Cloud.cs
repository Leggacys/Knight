using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    //Public Variable
    public float maxDistance;
    public float initialPozition;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= maxDistance)
            transform.position = new Vector2(initialPozition, 0);

        transform.Translate(new Vector3(speed * Time.deltaTime, 0));
    }
}
