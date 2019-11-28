using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaRotation : MonoBehaviour
{
    public Vector3 rotation;
    public float speed;

    void Update()
    {
        transform.RotateAround(transform.position, rotation, speed * Time.deltaTime);
    }
}
