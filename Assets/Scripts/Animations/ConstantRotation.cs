using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public float speed;
    public Vector3 rotation;

    void Update()
    {
        transform.Rotate(rotation * 360f * speed * Time.deltaTime);
    }
}
