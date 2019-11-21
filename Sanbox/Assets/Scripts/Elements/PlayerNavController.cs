using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavController : MonoBehaviour
{
    public LayerMask ground;
    public NavMeshAgent agent;

    public Transform navPointPrefab;
    public Transform structureNavPointPrefab;
    public NavPoint currentNavPoint;

    void OnEnable()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.tag == "Ground")
                {
                    agent.SetDestination(hit.point);
                    CreateNavPoint(hit);
                }

                if (hit.collider.tag == "Structure")
                {
                    agent.SetDestination(hit.collider.ClosestPoint(gameObject.transform.position));
                    Transform navPoint = CreateNavPoint(hit, hit.transform.position, structureNavPointPrefab);
                    navPoint.GetComponent<StructureNavPoint>().structure = hit.collider.gameObject;
                }
            }
        }
    }

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
}