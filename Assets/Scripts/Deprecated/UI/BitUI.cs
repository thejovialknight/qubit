using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitUI : MonoBehaviour
{
    public ResourceUIController controller;
    public QuantityUI ui;

    void Update()
    {
        if (controller.bitBank != null)
        {
            ui.quantity = controller.bitBank.bits;
        }
        else
        {
            ui.quantity = 0;
        }
    }
}