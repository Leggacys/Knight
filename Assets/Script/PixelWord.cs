using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelWord : MonoBehaviour
{
    //Public Variable
    public float speed;
    //Private Variable
    private Vector2 Destination;
    void Start()
    {
       StartCoroutine(Alpha());
        Destination.x = gameObject.transform.position.x;
        Destination.y = gameObject.transform.position.y +2;
        Destroy(gameObject, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Destination) > 0.2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Destination, speed * Time.deltaTime);
        }
    }

    IEnumerator Alpha()
    {
        float alpha = 1;
        while (alpha != 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
            alpha -= 0.2f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
