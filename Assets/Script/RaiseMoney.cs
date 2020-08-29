using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseMoney : MonoBehaviour
{
    private int number;
    public float timeBetweenEarnMoney;
    void Start()
    {
        Dictionary<string, bool> housNumbers = HousesManager.instance.ReturnValue();
        foreach (var item in housNumbers)
        {
            if (item.Value == true)
                number++;
        }

        StartCoroutine(AddMoney());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AddMoney()
    {
        GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().AddCoin(number);
        yield return new WaitForSeconds(timeBetweenEarnMoney);
        StartCoroutine(AddMoney());
    }
}
