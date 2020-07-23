using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManage : MonoBehaviour
{
    //Public Variables
    public GameObject transport;
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemies").Length == 0)
            transport.SetActive(true);
    }
}
