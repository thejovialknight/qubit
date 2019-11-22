using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinker : MonoBehaviour
{
    MeshRenderer meshRenderer;
    AnimationHelper rotationScript;
    public Vector3 rotationSpeed;
    public Vector3 scale;
    public Vector3 shrunkRotationSpeed;

    public float shrinkSpeed = 1f;
    public float scaleAcceleration = 10f;
    public float rotationAcceleration = 10f;
    public float expansionTime = 1f;
    public bool startsExpanded = false;
    public bool immediateChange = true;

    public bool isShrunk = false;
    public bool isExpanded = false;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rotationScript = GetComponent<AnimationHelper>();

        if (startsExpanded)
        {
            transform.localScale = scale;
            //rotationScript.rotation = rotationSpeed;
            isExpanded = true;
            meshRenderer.enabled = true;
            if(immediateChange)
            {
                StartCoroutine("Shrink");
            }
        }
        else
        {
            transform.localScale = Vector3.zero;
            //rotationScript.rotation = shrunkRotationSpeed;
            isShrunk = true;
            meshRenderer.enabled = false;
            if (immediateChange)
            {
                StartCoroutine("Expand");
            }
        }
    }

    IEnumerator Expand()
    {
        isShrunk = false;
        isExpanded = false;
        meshRenderer.enabled = true;

        Vector3 previousScale = transform.localScale;
        //Vector3 previousRotationSpeed = rotationScript.rotation;
        while (transform.localScale != scale)
        {
            transform.localScale = Vector3.Lerp(previousScale, scale, expansionTime * Time.deltaTime);
            //rotationScript.rotation = Vector3.Lerp(previousRotationSpeed, rotationSpeed, expansionTime * Time.deltaTime);
            Debug.Log("EXPANDING");
            yield return null;
        }

        transform.localScale = scale;
        //rotationScript.rotation = rotationSpeed;
        Debug.Log("EXPANDED");
        isExpanded = true;
        isShrunk = false;
    }

    IEnumerator Shrink()
    {
        isShrunk = false;
        isExpanded = false;
        while (transform.localScale.x > 0 && transform.localScale.y > 0 && transform.localScale.z > 0)
        {
            float currentShrinkSpeed = shrinkSpeed;
            transform.localScale -= new Vector3(currentShrinkSpeed, currentShrinkSpeed, currentShrinkSpeed) * Time.deltaTime;
            currentShrinkSpeed += scaleAcceleration * Time.deltaTime;
            //rotationScript.speed += rotationAcceleration * Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        //rotationScript.rotation = shrunkRotationSpeed;

        meshRenderer.enabled = false;
        isExpanded = false;
        isShrunk = true;
}
}
