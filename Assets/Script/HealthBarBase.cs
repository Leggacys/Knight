using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBase : MonoBehaviour
{
   public GameObject ourBase;
    void Start()
    {
        gameObject.GetComponent<Slider>().maxValue = ourBase.GetComponent<Base>().HP;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlider();
    }

    public void UpdateSlider()
    {

        gameObject.GetComponent<Slider>().value = ourBase.GetComponent<Base>().HP;
    }
}
