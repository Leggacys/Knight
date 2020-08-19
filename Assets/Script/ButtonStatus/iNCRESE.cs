using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iNCRESE : MonoBehaviour,IStatus
{
    private  Slider slider;
    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        if (StatusManager.instance.Exist(gameObject.name))
            slider.value = StatusManager.instance.Return(gameObject.name);
         StatusManager.instance.Memorize(gameObject.name, (int)slider.value);
    }

    public void Add()
    {
        if(slider.value+1<=slider.maxValue)
        {
        slider.value += 1;
        StatusManager.instance.IncreseValue(slider.name, slider.value);
        }
    }
}
