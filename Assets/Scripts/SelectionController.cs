using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    // HAND CONTROL OF SELECTOR OBJECTS OVER TO THOSE WHO ARE SELECTED PERCHANCE? ANOTHER SCRIPT TO HANDLE THIS ATTACHED TO SELECTED GAME OBJECT.

    /*
     * SELECTIONS DEFINE THEIR BEHAVIOR WITH RESPECT TO CONTROLS USING INTERFACES
     * NOTHING SPECIFIC DEFINED BY THIS SCRIPT
     */

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Select(hit);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                Control(hit);
            }
        }
    }

    void Select(RaycastHit hit)
    {
        if (hit.transform.CompareTag("Terrain"))
        {
            EventManager.DeselectEvent();
        }

        ISelectable selectable = hit.transform.GetComponent<ISelectable>();
        if(selectable != null)
        {
            GameObject[] objects = { hit.transform.gameObject };
            EventManager.SelectEvent(objects);
        }
    }

    void Control(RaycastHit hit)
    {

        /* REPLACE THESE IFS WITH CHECKS FOR INTERFACES
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
        */
    }
}
