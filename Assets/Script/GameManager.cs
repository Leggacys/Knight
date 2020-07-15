using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //Private Variable
    public static  GameManager instance = null;
    private GameObject _player;
    private GameObject _tranferPanel;
    private Dictionary<string,bool> _houses=new Dictionary<string, bool>();


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

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        _player=GameObject.FindGameObjectWithTag("Player");
        _tranferPanel=GameObject.FindGameObjectWithTag("TransferPanel");
        
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
        if (_houses.Count == 0)
            return true;
        return false;
    }
}
