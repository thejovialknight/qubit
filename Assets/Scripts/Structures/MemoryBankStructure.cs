using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBankStructure : MonoBehaviour, IInteractable
{
    public BitBank bank;

    public void Interact(GameObject bitbot)
    {
        BitBank botBank = bitbot.GetComponent<BitBank>();
        if(botBank.bits > 0)
        {
            BitBank.Transfer(botBank, bank, botBank.bits);
        }
    }
}
