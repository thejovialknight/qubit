using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavPoint : MonoBehaviour
{
    public Vector3 offset;

    public NavMeshAgent agent;

    private void OnEnable()
    {
        EventManager.onSelectEvent += OnSelect;
        EventManager.onDeselectEvent += OnDeselect;
    }

    private void OnDisable()
    {
        EventManager.onSelectEvent -= OnSelect;
        EventManager.onDeselectEvent -= OnDeselect;
    }

    void OnSelect(GameObject selection)
    {
        if(GameObject.ReferenceEquals(selection, agent.gameObject))
        {
            GetComponent<Shrinker>().StartCoroutine("Expand");
        }
    }

    void OnDeselect(GameObject selection)
    {
        if(GameObject.ReferenceEquals(selection, agent.gameObject))
        {
            GetComponent<Shrinker>().StartCoroutine("Shrink");
        }
    }

    void Start()
    {
        transform.position = transform.position + offset;
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
        GetComponent<ShrinkAndDestroy>().StartCoroutine("Destroy");
        this.enabled = false;
    }
}
