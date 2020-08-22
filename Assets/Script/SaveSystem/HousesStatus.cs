using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class DataSaved
{ 

    public Dictionary<string, bool> _houses = new Dictionary<string, bool>();
    public Dictionary<string, bool> _soldierHouses = new Dictionary<string, bool>();
    public int money;
    public Dictionary<string, float> _status = new Dictionary<string, float>();
    

    public DataSaved(int a)
    {
        _houses = HousesManager.instance.ReturnValue();
        _soldierHouses = CazarmManager.instance.ReturnValue();
        _status = StatusManager.instance.ReturnValue();
        money = GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().ReturnValue();

    }
    //This is for restart the game from 0
    public DataSaved(float a)
    {
        _houses = new Dictionary<string, bool>();
        _soldierHouses = new Dictionary<string, bool>();
        _status = new Dictionary<string, float>();
        money = 0;
    }

}
