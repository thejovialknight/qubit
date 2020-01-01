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

    public Camera cam;
    public RenderTexture renderTexture;

    void Update()
    {
        // this is broken fix later
        Ray ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x / ((float)Screen.width / (float)renderTexture.width), Input.mousePosition.y / ((float)Screen.height / (float)renderTexture.height), 0));
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
        EventManager.DeselectEvent();
        GameObject[] objects = { hit.transform.gameObject };
        EventManager.SelectEvent(objects);
    }

    void Control(RaycastHit hit)
    {
        EventManager.ControlEvent(hit);
    }
}
