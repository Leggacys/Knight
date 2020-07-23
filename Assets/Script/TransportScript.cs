using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportScript : MonoBehaviour
{
    //Public Variables
    public TransferPanel panel;
    public GameObject arrow;

    public void Awake()
    {
        arrow.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            panel.LoadScene(0);
        }
    }
}
