using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavPoint : MonoBehaviour
{
    public Vector3 offset;

    public NavMeshAgent agent;
    public Animator animator;

    void OnEnable()
    {
        EventManager.onSelectEvent += OnSelect;
        EventManager.onDeselectEvent += OnDeselect;
    }

    void OnDisable()
    {
        EventManager.onSelectEvent -= OnSelect;
        EventManager.onDeselectEvent -= OnDeselect;
    }

    void OnSelect(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            if (GameObject.ReferenceEquals(obj, agent.gameObject))
            {
                animator.SetBool("Expanding", true);
            }
        }
    }

    void OnDeselect()
    {
        if(GameObject.ReferenceEquals(selection, agent.gameObject))
        {
            animator.SetBool("Shrinking", true);
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        transform.position = transform.position + offset;
        animator.SetFloat("yScale", 0.05f);
    }

    void Update()
    {
        if(agent.remainingDistance < 1)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        animator.SetBool("Destroy", true);
        this.enabled = false;
    }
}
