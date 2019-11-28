using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    // do we need position update every frame?

    // public Transform selected;
    float yOffset;
    float size;

    Animator animator;

    public void Initialize(float size, float yOffset) {
        // this.selected = selected;
        this.yOffset = yOffset;
        this.size = size;
        animator.SetFloat("xScale", size);
        animator.SetFloat("yScale", 0.05f);
        animator.SetFloat("zScale", size);
    }

    void Awake() 
    {
        animator = GetComponent<Animator>();
    }

    void Update() 
    {
        transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);
    }

    public void Destroy() 
    {
        animator.SetBool("Destroy", true);
    }
}
