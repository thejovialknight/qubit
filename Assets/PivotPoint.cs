using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotPoint : MonoBehaviour
{
    void Update()
    {
        transform.position = Camera.main.transform.position + new Vector3(-7, -11, 7);
    }
}
