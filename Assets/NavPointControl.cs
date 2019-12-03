using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavPointControl : MonoBehaviour
{
    public Transform navPointPrefab;
    public NavPoint currentNavPoint;

    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    /*
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
            if (GameObject.ReferenceEquals(obj, gameObject))
            {
                currentNavPoint.Destroy();
            }
        }
    }

    void OnDeselect()
    {
        currentNavPoint.Destroy();
    }
    */

    public Transform CreateNavPoint(RaycastHit hit, Vector3 position, Transform prefab)
    {
        if (currentNavPoint != null)
        {
            currentNavPoint.Destroy();
        }
        Transform navPointObject = GameObject.Instantiate(prefab, position, Quaternion.identity);
        currentNavPoint = navPointObject.GetComponent<NavPoint>();
        currentNavPoint.agent = agent;
        return navPointObject;
    }

    public Transform CreateNavPoint(RaycastHit hit)
    {
        return CreateNavPoint(hit, hit.point, navPointPrefab);
    }
}
