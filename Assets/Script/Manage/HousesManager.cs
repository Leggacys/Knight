using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
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

    public void Change(string key, bool value)
    {
        _houses[key] = value;
    }

    public void SaveHouses()
    {
        foreach (var e in _houses)
            Debug.Log(e.Key + " " + e.Value);
        SaveSystem.SaveHouses();
    }

    public void LoadHouses()
    {
        HousesStatus hous = SaveSystem.Load();
        _houses.Clear();
        foreach (var item in hous._houses)
        {
            _houses.Add(item.Key, item.Value);
            Debug.Log(item.Key + " " + item.Value);
        }

        SceneManager.LoadScene(0);
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
}
