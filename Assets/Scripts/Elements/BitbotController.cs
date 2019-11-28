using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BitbotController : MonoBehaviour
{
    public bool selected;

    public Transform navPointPrefab;
    public Transform structureNavPointPrefab;
    public NavPoint currentNavPoint;

    NavMeshAgent agent;
    NavPointControl navPointControl;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        navPointControl = GetComponent<NavPointControl>();
    }

    void OnEnable()
    {
        EventManager.onSelectEvent += OnSelect;
        EventManager.onDeselectEvent += OnDeselect;
        EventManager.onControlEvent += OnControl;
    }

    void OnDisable()
    {
        EventManager.onSelectEvent -= OnSelect;
        EventManager.onDeselectEvent -= OnDeselect;
        EventManager.onControlEvent -= OnControl;
    }

    void OnSelect(GameObject[] objects)
    {
        foreach(GameObject obj in objects)
        {
            if(GameObject.ReferenceEquals(obj, gameObject))
            {
                selected = true;
            }
        }
    }

    void OnDeselect()
    {
        selected = false;
    }

    void OnControl(RaycastHit hit)
    {
        if (selected)
        {
            if (hit.collider.tag == "Terrain")
            {
                agent.SetDestination(hit.point);
                navPointControl.CreateNavPoint(hit);
            }

            if (hit.collider.tag == "Structure")
            {
                agent.SetDestination(hit.collider.ClosestPoint(gameObject.transform.position));
                Transform navPoint = navPointControl.CreateNavPoint(hit, hit.transform.position, structureNavPointPrefab);
                navPoint.GetComponent<StructureNavPoint>().structure = hit.collider.gameObject;
            }
        }
    }

    /*
    Transform CreateNavPoint(RaycastHit hit, Vector3 position, Transform prefab)
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

    Transform CreateNavPoint(RaycastHit hit)
    {
        return CreateNavPoint(hit, hit.point, navPointPrefab);
    }
    */
}