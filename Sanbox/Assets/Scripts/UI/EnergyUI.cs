using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUI : MonoBehaviour
{
    public ResourceUIController controller;
    public QuantityUI ui;

    void Update()
    {
        if (controller.energyBank != null)
        {
            ui.quantity = controller.energyBank.energy;
        }
        else
        {
            ui.quantity = 0;
        }
    }
}
