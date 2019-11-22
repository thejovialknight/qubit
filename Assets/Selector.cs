using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public Transform selected;
    float yOffset;

    AnimationHelper animationHelper;
    Animator animator;

    public void Initialize(Transform selected, float size, float yOffset) {
        this.selected = selected;
        this.yOffset = yOffset;
        animationHelper.size = new Vector3(size, 0.05f, size);
    }

    void Awake() 
    {
        animationHelper = GetComponent<AnimationHelper>();
        animator = GetComponent<Animator>();
    }

    void Update() 
    {
        transform.position = new Vector3(selected.position.x, yOffset, selected.position.z);
    }

    public void Destroy() 
    {
        animator.SetBool("Destroy", true);
    }
}
