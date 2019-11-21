using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BodyFollow : MonoBehaviour
{
    public Transform head;
    public NavMeshAgent agent;
    public float lookSpeed;

    // FUCKING FIX IT
    void Update()
    {
        Vector3 direction = head.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, lookSpeed * Time.deltaTime);
    }
}
