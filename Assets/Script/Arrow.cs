using System;
using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Public Variable
    public float frontSpeed;
    public float backSpeed;
    //Private Variable
    private Vector2 position;
    private Vector2 initialPosition;
    void Start()
    {
        position.x = transform.position.x + 4;
        position.y = transform.position.y;
        initialPosition = transform.position;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator Move()
    {
        while (Math.Abs(transform.position.x-position.x)>0.2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, position, frontSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        while (Math.Abs(transform.position.x - initialPosition.x) > 0.2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, backSpeed* Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(Move());
    }
}
