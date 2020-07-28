using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HousesStatus
{
    public Dictionary<string, bool> _houses = new Dictionary<string, bool>();

    public HousesStatus(int a)
    {
        _houses = GameManager.instance.ReturnValue();
    }
}
