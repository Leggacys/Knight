using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iNCRESE : MonoBehaviour,IStatus
{
    private  Slider slider;
    public float value = 1;
    public int number;
    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        if (StatusManager.instance.Exist(gameObject.name))
            slider.value = StatusManager.instance.Return(gameObject.name);
         StatusManager.instance.Memorize(gameObject.name, (int)slider.value);
    }

    public void Add()
    {
        int nr;
        float p;
        if (slider.value < 1)
        {
            p = slider.value;
            nr = (int)(p * 10);
        }
        else
        {
            nr = (int)slider.value;
        }
           
        if(slider.value+value<=slider.maxValue&&StatusManager.instance.MoneyForStatus(
            nr,number))
        {
        slider.value += value;
        StatusManager.instance.IncreseValue(slider.name, slider.value);
        }
    }
}
