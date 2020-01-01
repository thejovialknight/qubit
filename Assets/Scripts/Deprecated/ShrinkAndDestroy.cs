using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAndDestroy : MonoBehaviour
{
    Shrinker shrinker;

    void Awake()
    {
        shrinker = GetComponent<Shrinker>();
    }

    IEnumerator Destroy()
    {
        shrinker.StartCoroutine("Shrink");
        while(!shrinker.isShrunk)
        {
            yield return null;
        }
        GameObject.Destroy(gameObject);
    }
}
