using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CazarmManager : MonoBehaviour
{
    //Public Variables
    public static CazarmManager instance;
    //Private Variables
    private Dictionary<string, bool> _houses = new Dictionary<string, bool>();
    void Start()
    {
        
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Memorize(string key, bool value)
    {
        if (!_houses.ContainsKey(key))
            _houses.Add(key, value);
        
    }

    public void Change(string key, bool value)
    {
        _houses[key] = value;
        
    }

    public bool Exist(string key)
    {
        if (!_houses.ContainsKey(key))
            return false;
        return true;
    }

    public bool ReturnValue(string key)
    {
        return _houses[key];
    }
    public Dictionary<string, bool> ReturnValue()
    {
        return _houses;
    }

    public void LoadData(Dictionary<string, bool> _houses)
    {
        this._houses.Clear();
        foreach (var item in _houses)
        {
            this._houses.Add(item.Key, item.Value);
             Debug.Log(item.Key+" "+item.Value);
        }
    }
}
