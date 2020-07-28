using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //Public Variables
    public float speed;
    public float time;
    public int damage;
    private void Start()
    {
        Destroy(gameObject, time);
    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Soldier")
        {
            collision.GetComponent<IHititSolediers>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
