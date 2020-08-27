using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEXTVALUE : MonoBehaviour
{
    public Slider slider;
    public string name;
    // Update is called once per frame
    void Update()
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
        gameObject.GetComponent<Text>().text = StatusManager.instance.TextModifai(name, nr).ToString();
    }
}
