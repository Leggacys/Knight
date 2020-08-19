using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HousesManager : MonoBehaviour
{
      private Dictionary<string, bool> _houses=new Dictionary<string, bool>();
    //Public Variable
    public static HousesManager instance = null;
    // Start is called before the first frame update
   public void Start()
    {
        
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            if(instance!=this)
                Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public  bool ReturnValue(string key)
    {
        return _houses[key];
    }

    public bool Exist(string key)
    {
        if (_houses.ContainsKey(key))
            return true;
        return false;
    }

            public void Change(string key, bool value)
    {
        _houses[key] = value;
    }

   

    public Dictionary<string,bool> ReturnValue()
    {
        return _houses;
    }

    public void Memorize(bool value,string key)
    {
        if(!_houses.ContainsKey(key))
        _houses.Add(key, value);
       
    }
    public void LoadData(Dictionary<string, bool> _houses)
    {
        this._houses = new Dictionary<string, bool>(_houses);
    }
}
