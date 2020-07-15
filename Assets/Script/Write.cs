using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Write : MonoBehaviour
{
    // Start is called before the first frame update
    //Public Variables
    public float speed;
    public TextMeshPro text;
    //Private Variables
    private Vector2 Destination;

    void Start()
    {
        StartCoroutine(Alpha());
        Destination.x = gameObject.transform.position.x;
        Destination.y = gameObject.transform.position.y-4;
        Destroy(gameObject,3f);
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
        while (alpha !=0)
        {
            text.color = new Color(250,255,0,alpha);
            alpha -= 0.2f;
            yield return new WaitForSeconds(0.5f);
        }
    }



}
