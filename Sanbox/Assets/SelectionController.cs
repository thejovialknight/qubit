using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    GameObject selection = null;
    float yOffset = 0.25f;

    Shrinker shrinker;
    public SelectorAnimation selectorAnimation;
    public MeshRenderer meshRenderer;

    void Awake()
    {
        shrinker = GetComponent<Shrinker>();
    }

    void Update()
    {
        if (shrinker.isExpanded)
        {
            selectorAnimation.enabled = true;
        }
        else
        {
            selectorAnimation.enabled = false;
        }

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
                    yOffset = 0.25f;
                    selectorAnimation.size = 1.5f;
                    SelectObject(hit.collider.gameObject);
                    selection.GetComponent<PlayerNavController>().enabled = true;
                }
                else if (hit.collider.CompareTag("Structure"))
                {
                    yOffset = 0.125f;
                    selectorAnimation.size = 5f;
                    SelectObject(hit.collider.gameObject);
                }
            }
        }

        if(selection != null)
        {
            transform.position = new Vector3(selection.transform.position.x, yOffset, selection.transform.position.z);
        }
    }

    void SelectObject(GameObject obj)
    {
        GetComponent<Shrinker>().StartCoroutine("Expand");
        selection = obj;
        EventManager.SelectEvent(selection);
    }

    void DeselectObject()
    {
        EventManager.DeselectEvent(selection);
        shrinker.StartCoroutine("Shrink");
        PlayerNavController navController = selection.GetComponent<PlayerNavController>();
        if (navController != null)
        {
            navController.enabled = false;
        }
    }
}
