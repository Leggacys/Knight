using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //Private Variable
    private GameObject _player;
    private GameObject _tranferPanel;
  
    void Start()
    {
        _player=GameObject.FindGameObjectWithTag("Player");
        _tranferPanel=GameObject.FindGameObjectWithTag("TransferPanel");
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (_player == null)
            _tranferPanel.GetComponent<TransferPanel>().LoadScene(1);
        if (_player!=null&&GameObject.FindGameObjectsWithTag("Enemies").Length==0)
            _tranferPanel.GetComponent<TransferPanel>().LoadScene(1);
    }

    
}
