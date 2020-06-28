using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;

    void Start()
    {
       
    }

    
    public void ChangeAlpha()
    {
        gameObject.SetActive(true);
        Dezactivated();
    
    }

    public void Dezactivated()
    {
        canvas.SetActive(false);
    }

   
}
