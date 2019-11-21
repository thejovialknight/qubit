using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    Renderer renderer;
    Material material;

    public Vector4 materialColor;
    public float onLuminosity = 1;
    public float offLuminosity = 0;
    public float luminositySpeed = 5f;

    float currentLuminosity = 0;
    float desiredLuminosity = 0;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
        currentLuminosity = 0;
        desiredLuminosity = 0;
    }

    public void TurnOn()
    {
        desiredLuminosity = onLuminosity;
    }

    public void TurnOff()
    {
        desiredLuminosity = offLuminosity;
    }

    void Update()
    {
        currentLuminosity = Mathf.Lerp(currentLuminosity, desiredLuminosity, luminositySpeed * Time.deltaTime);
        Color c = GetComponent<Renderer>().material.color;
        material.SetColor("_EmissionColor", new Vector4(c.r, c.g, c.b,0) * currentLuminosity);
    }
}
