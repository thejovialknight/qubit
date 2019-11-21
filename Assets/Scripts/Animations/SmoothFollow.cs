using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.5f;
    public Vector3 offset;

    Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(target.position + offset, 1);
    }
}
