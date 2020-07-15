using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

 
public class HousesManager : MonoBehaviour
{
    //Private Variable
    private static int _count = 0;
    
    private Dictionary<string, bool> _houses=new Dictionary<string, bool>();
    //Public Variable
    public static HousesManager instance = null;
    // Start is called before the first frame update
   public void Start()
    {
        
        if(GameManager.instance.EmptyIf()==true)
            GameManager.instance.Memorize(_houses);
        else
            Load();
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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Memorize(bool value,string name)
    {
        if(_houses.ContainsKey(name)==false)
      _houses.Add(name,value);
    }

    public  bool ReturnValue(string key)
    {
        return _houses[key];
    }

    private void Load()
    {
        _houses = GameManager.instance.ReturnValue();
    }

    public void Change(string key, bool value)
    {
        _houses[key] = value;
    }
}
