using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Net.Http.Headers;
using System.ComponentModel.Design;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //Private Variable
    public static  GameManager instance = null;
    private GameObject _player;
    private GameObject _tranferPanel;
    private Dictionary<string,bool> _houses=new Dictionary<string, bool>();
    private  static bool _firtstTime = true;
    //Public Variables
    public GameObject moveMenu;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance!=this)
                Destroy(gameObject);
        }
        Debug.Log(Application.persistentDataPath);
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        if(moveMenu!=null)
        moveMenu.SetActive(false);
        _player=GameObject.FindGameObjectWithTag("Player");
        _tranferPanel=GameObject.FindGameObjectWithTag("TransferPanel");
        FirstTime();
        _firtstTime = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null)
            _tranferPanel.GetComponent<TransferPanel>().LoadScene(0);
    }

    public Dictionary<string,bool> ReturnValue()
    {
        return _houses;
    }

    public void Memorize(Dictionary<string,bool> hous)
    {
        _houses = hous;
    }

    public bool EmptyIf()
    {
        foreach (var item in _houses)
        {
            if (item.Value == true)
                return false;
        }
            return true;
       
    }
    private void FirstTime()
    {    
        if (_firtstTime ==false&&GameObject.FindGameObjectsWithTag("MainMenu")!=null )
        {
            GameObject.FindGameObjectWithTag("MainMenu").SetActive(false);
            moveMenu.SetActive(true);
            
        }
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
    }




}
