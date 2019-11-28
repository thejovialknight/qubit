using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenterStructure : MonoBehaviour, IInteractable
{
    public BitBank bitBank;
    public EnergyBank energyBank;
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
        EnergyBank botEnergyBank = bitbot.GetComponent<EnergyBank>();
        if (botEnergyBank.energy > 0)
        {
            EnergyBank.Transfer(botEnergyBank, energyBank, botEnergyBank.energy);
        }

        BitBank botBitBank = bitbot.GetComponent<BitBank>();
        if (botBitBank.bits > 0)
        {
            BitBank.Transfer(botBitBank, bitBank, botBitBank.bits);
        }
    }
}
