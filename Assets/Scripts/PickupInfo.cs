﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInfo : MonoBehaviour
{
    public int valueMin;
    public int valueMax;

    public float size;
    public int value;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        value = Random.Range(valueMin, valueMax);
        size = value * 0.1f;

        transform.localScale = new Vector3(transform.localScale.x * size, transform.localScale.y * size, transform.localScale.z * size);
        animator.SetFloat("xScale", transform.localScale.x * size);
        animator.SetFloat("yScale", transform.localScale.y * size);
        animator.SetFloat("zScale", transform.localScale.z * size);
        transform.localRotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
    }
}
