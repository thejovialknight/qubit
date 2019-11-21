using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBankStructure : MonoBehaviour, IInteractable
{
    public EnergyBank bank;

    public void Interact(GameObject bitbot)
    {
        EnergyBank botBank = bitbot.GetComponent<EnergyBank>();
        if(botBank.energy > 0)
        {
            EnergyBank.Transfer(botBank, bank, botBank.energy);
        }
    }
}
