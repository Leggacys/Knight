using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    void Start()
    {
         Destroy(gameObject,time);        
    }

   
}
