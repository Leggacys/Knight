using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DataSaved
{ 

    public Dictionary<string, bool> _houses = new Dictionary<string, bool>();
    

    public DataSaved(int a)
    {
        _houses = HousesManager.instance.ReturnValue();

    }
}
