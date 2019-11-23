using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StructureNavPoint : MonoBehaviour
{
    public NavPoint navPoint;
    public GameObject structure;

    Animator animator;

    void Awake()
    {
        navPoint = GetComponent<NavPoint>();
        animator = GetComponent<Animator>();
    }

    void Start() {
        animator.SetFloat("xScale", 5f);
        animator.SetFloat("zScale", 5f);
    }

    void Update()
    {
        if (navPoint.agent.remainingDistance < 3)
        {
            navPoint.agent.ResetPath();
            structure.GetComponent<IInteractable>().Interact(navPoint.agent.gameObject);
            Destroy();
        }
    }

    public void Destroy()
    {
        navPoint.Destroy();
        this.enabled = false;
    }
}
