using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    //Public
    public Transform target;
    public UnityEngine.Vector3 offset;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float speed;
    //Private
    private float _smoothSpeed = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        UnityEngine.Vector3 desirePosition = target.position + offset;
        UnityEngine.Vector3 smoothLerp = UnityEngine.Vector3.Lerp(transform.position, desirePosition, _smoothSpeed);
        transform.position = smoothLerp;
         
    }

    

}
