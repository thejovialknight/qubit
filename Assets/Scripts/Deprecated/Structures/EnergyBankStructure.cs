using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBankStructure : MonoBehaviour, IInteractable
{
    public EnergyBank bank;
    public bool selected;

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
                selected = true;
            }
        }
    }

    void OnDeselect()
    {
        selected = false;
    }

    public void Interact(GameObject bitbot)
    {
        EnergyBank botBank = bitbot.GetComponent<EnergyBank>();
        if(botBank.energy > 0)
        {
            EnergyBank.Transfer(botBank, bank, botBank.energy);
        }
    }
}
