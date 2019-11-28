using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorControl : MonoBehaviour
{
    public Transform selectorPrefab;
    public Transform selectorObject;
    public Selector selector;

    public float size;
    public float yOffset;

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
                CreateSelector();
            }
        }
    }

    void OnDeselect()
    {
        DestroySelector();
    }

    void CreateSelector()
    {
        selectorObject = GameObject.Instantiate(selectorPrefab, transform.position, Quaternion.Euler(Vector3.zero), transform);
        selector = selectorObject.GetComponent<Selector>();
        selector.Initialize(size, yOffset);
    }

    void DestroySelector()
    {
        if(selector)
        {
            selector.Destroy();
            selector = null;
        }
    }
}
