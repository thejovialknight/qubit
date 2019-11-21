using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuantityUI : MonoBehaviour
{
    public Text text;
    public int quantity;
    public RectTransform panel;

    public int currentNumber = 0;
    public float countSpeed = 0.1f;
    float currentCooldown = 0f;

    void Update()
    {
        if(currentCooldown < 0 && currentNumber < quantity)
        {
            currentCooldown = countSpeed;
            currentNumber++;
        }
        
        if(currentCooldown < 0 && currentNumber > quantity)
        {
            currentCooldown = countSpeed;
            currentNumber--;
        }

        currentCooldown -= Time.deltaTime;

        text.text = currentNumber.ToString();
    }
}
