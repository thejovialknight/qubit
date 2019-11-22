using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StructureNavPoint : MonoBehaviour
{
    public NavPoint navPoint;
    public GameObject structure;

    void Start()
    {
        navPoint = GetComponent<NavPoint>();
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
