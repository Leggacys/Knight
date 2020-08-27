using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HleathBar : MonoBehaviour
{
    //Private variable
    //Public Variables
   private  Player _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameObject.GetComponent<Slider>().maxValue = _player.health;    
    }

    private void Update()
    {
        UpdateSlider();
    }

    public void UpdateSlider()
    {
        
        gameObject.GetComponent<Slider>().value = _player.health;
    }
    
   

}
