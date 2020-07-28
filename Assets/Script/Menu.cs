using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    public GameObject moveCanvas;
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
        moveCanvas.SetActive(true);
    }

   
}
