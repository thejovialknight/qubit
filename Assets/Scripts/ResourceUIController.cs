using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceUIController : MonoBehaviour
{
    public BitBank bitBank;
    public EnergyBank energyBank;

    private void OnEnable()
    {
        EventManager.onSelectEvent += OnSelected;
        EventManager.onDeselectEvent += OnDeselected;
    }

    private void OnDisable()
    {
        EventManager.onSelectEvent -= OnSelected;
        EventManager.onDeselectEvent -= OnDeselected;
    }

    void OnSelected(GameObject selection)
    {
        bitBank = selection.GetComponent<BitBank>();
        energyBank = selection.GetComponent<EnergyBank>();
    }

    void OnDeselected(GameObject selection)
    {
        bitBank = null;
        energyBank = null;
    }
}
