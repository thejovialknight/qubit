using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    GameObject selection = null;

    public Transform selectorPrefab;
    public Selector currentSelector;

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(selection != null)
                {
                    DeselectObject();
                }

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
            }
        }
    }

    void SelectObject(GameObject obj, float selectorSize, float yOffset)
    {
        currentSelector = GameObject.Instantiate(selectorPrefab).GetComponent<Selector>();
        currentSelector.Initialize(obj.transform, selectorSize, yOffset);
        selection = obj;
        EventManager.SelectEvent(selection);
    }

    void DeselectObject()
    {
        EventManager.DeselectEvent(selection);
        if(currentSelector != null) {
            currentSelector.Destroy();
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
