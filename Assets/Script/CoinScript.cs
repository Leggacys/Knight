using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Text text;
    public  int coinAmount=0;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString();
    }

    public bool CoinAmount(int price)
    {
        
        if (coinAmount >= price)
        {
            coinAmount -= price;
            
            return true;
        }
        
        return false;

    }
}
