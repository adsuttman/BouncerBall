using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeArea : MonoBehaviour
{
    public Vector3 minScale = new Vector3(0.15f,0.15f,0.15f);
    public Vector3 maxScale = new Vector3(1f,1f,1f);
    public Vector3 scaleAmount = new Vector3(0.2f,0.2f,0.2f);
    public bool grow = true;
    public LayerMask ballLayer;



    void OnTriggerStay2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        Vector3 scale = obj.transform.localScale;
        if (grow)
        {
            obj.transform.localScale = ClampScale(scale + scaleAmount * Time.deltaTime);
        }
        else
        {
            obj.transform.localScale = ClampScale(scale - scaleAmount * Time.deltaTime);
        }
    }
    Vector3 ClampScale(Vector3 scale)
    {
       if (scale.x > maxScale.x)
       {
            return maxScale;
       }
       else if (scale.x < minScale.x)
       {
            return minScale;
       }
       else
        {
            return scale;
        }
    }
}
