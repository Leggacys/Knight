using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoldier : MonoBehaviour
{
    //Public Variables
    public GameObject[] soldiers;
    void Start()
    {
        foreach(var e in soldiers)
        {
            Instantiate(e, transform.position, transform.rotation);
        }
    }

}
