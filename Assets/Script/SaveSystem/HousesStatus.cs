using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DataSaved
{ 

    public Dictionary<string, bool> _houses = new Dictionary<string, bool>();
    public Dictionary<string, bool> _soldierHouses = new Dictionary<string, bool>();
    

    public DataSaved(int a)
    {
        _houses = HousesManager.instance.ReturnValue();
        _soldierHouses = CazarmManager.instance.ReturnValue();

    }

    public DataSaved(float a)
    {
        _houses = new Dictionary<string, bool>();
        _soldierHouses = new Dictionary<string, bool>();
    }

}
