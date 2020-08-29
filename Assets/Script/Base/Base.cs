using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour,IHititSolediers
{
    private GameObject _transferPanel;
    public float HP;

    void Start()
    {
        _transferPanel = GameObject.FindGameObjectWithTag("TransferPanel");
    }

   
    public void Transport()
    {
        _transferPanel.GetComponent<TransferPanel>().LoadScene(0);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log(damage);
        if(HP<0)
        {
            Transport();
        }
    }
}
