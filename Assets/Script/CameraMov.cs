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
   

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        UnityEngine.Vector3 desirePosition = target.position + offset;
        // UnityEngine.Vector3 smoothLerp = UnityEngine.Vector3.Lerp(transform.position, desirePosition, _smoothSpeed);
        //transform.position = smoothLerp;
        if (target!= null)
        {
            float clampedx = Mathf.Clamp(target.position.x, minX, maxX);
            float clampedy = Mathf.Clamp(target.position.y, minY, maxY);
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedx, clampedy), speed);
        }
    }



}
