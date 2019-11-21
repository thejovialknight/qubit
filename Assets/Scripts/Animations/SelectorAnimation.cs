using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorAnimation : MonoBehaviour
{
    public float speed;
    public float size;
    public float shrinkSize;

    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 scale = transform.localScale;
        //calculate what the new Y position will be
        float newSize = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.localScale = new Vector3((newSize * shrinkSize) + size, scale.y, (newSize * shrinkSize) + size);
    }
}
