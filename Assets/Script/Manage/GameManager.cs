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


    private void FirstTime()
    {    
        if (_firtstTime ==false&&GameObject.FindGameObjectsWithTag("MainMenu")!=null )
        {
            GameObject.FindGameObjectWithTag("MainMenu").SetActive(false);
            moveMenu.SetActive(true);
            
        }
    }
   

}
