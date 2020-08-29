using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemyScript : MonoBehaviour
{
    public GameObject ourBase;
    void Start()
    {
        gameObject.GetComponent<Slider>().maxValue = ourBase.GetComponent<EvilBase>().HP;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlider();
    }

    public void UpdateSlider()
    {

        gameObject.GetComponent<Slider>().value = ourBase.GetComponent<EvilBase>().HP;
    }
}
