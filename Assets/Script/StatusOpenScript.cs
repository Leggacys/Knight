using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusOpenScript : MonoBehaviour
{
    public GameObject status;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if (gameObject.GetComponent<SoldierHous>()._bought == true)
                status.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            status.SetActive(false);
    }
}
