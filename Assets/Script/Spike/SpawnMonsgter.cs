using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMonsgter : MonoBehaviour
{
    //Public Variables
    public Slider slider;
    public GameObject Monster;
    //Private variables
    private int _spawnnValue;

    public void Start()
    {
        StartCoroutine(SetValue());
    }

    public void Update()
    {
       if(slider.value<=_spawnnValue)
        {
            Instantiate(Monster, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    IEnumerator SetValue()
    {
        yield return new WaitForSeconds(0.5f);
        _spawnnValue = (int)slider.GetComponent<Slider>().maxValue / 2;
    }

}
