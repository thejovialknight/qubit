using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnSelectEvent(GameObject selection);

    public static event OnSelectEvent onSelectEvent;
    public static void SelectEvent(GameObject selection)
    {
        if (onSelectEvent != null)
        {
            onSelectEvent(selection);
        }
    }

    public static event OnSelectEvent onDeselectEvent;
    public static void DeselectEvent(GameObject selection)
    {
        if (onDeselectEvent != null)
        {
            onDeselectEvent(selection);
        }
    }
}
