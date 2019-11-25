using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    GameObject selection = null;

    public Transform selectorPrefab;

    public List<Transform> currentSelection = new List<Transform>();
    public List<Selector> currentSelector = new List<Selector>(); // HAND CONTROL OF SELECTOR OBJECTS OVER TO THOSE WHO ARE SELECTED PERCHANCE? ANOTHER SCRIPT TO HANDLE THIS ATTACHED TO SELECTED GAME OBJECT.

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
        if (!GameObject.ReferenceEquals(hit.transform, currentSelection))
        {
            if (selection != null)
            {
                DeselectObject();
            }

            /* REPLACE THESE IFS WITH CHECKS FOR INTERFACES
            if (hit.collider.CompareTag("Bitbot"))
            {
                SelectObject(hit.collider.gameObject, 1.5f, 0.25f);

                // make bitbot do this when event is fired. In fact, this will allow the selector to be entirely programmatic
                selection.GetComponent<PlayerNavController>().enabled = true;
            }
            else if (hit.collider.CompareTag("Structure"))
            {
                SelectObject(hit.collider.gameObject, 5f, 0.125f);
            }
            */
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

    void SelectObject(GameObject obj, float selectorSize, float yOffset)
    {
        //currentSelection = obj.transform;
        //currentSelector = GameObject.Instantiate(selectorPrefab).GetComponent<Selector>();
        //currentSelector.Initialize(obj.transform, selectorSize, yOffset);
        selection = obj;
        EventManager.SelectEvent(selection);
    }

    void DeselectObject()
    {
        EventManager.DeselectEvent(selection);
        if(currentSelector != null) {
            //currentSelector.Destroy();
            currentSelection = null;
            currentSelector = null;
        }

        // must relegate this elsewhere as well if im honest
        PlayerNavController navController = selection.GetComponent<PlayerNavController>();
        if (navController != null)
        {
            navController.enabled = false;
        }
    }
}
