using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnSelectEvent(GameObject[] objects);
    public static event OnSelectEvent onSelectEvent;
    public static void SelectEvent(GameObject[] objects)
    {
        if (onSelectEvent != null)
        {
            onSelectEvent(objects);
        }
    }

    public delegate void OnDeselectEvent();
    public static event OnDeselectEvent onDeselectEvent;
    public static void DeselectEvent()
    {
        if (onDeselectEvent != null)
        {
            onDeselectEvent();
        }
    }

    public delegate void OnInteractEvent(GameObject obj);
    public static event OnInteractEvent onInteractEvent;
    public static void InteractEvent(GameObject obj)
    {
        if (onInteractEvent != null)
        {
            onInteractEvent(obj);
        }
    }
}
