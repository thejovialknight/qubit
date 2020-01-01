using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitBankStructure : MonoBehaviour, IInteractable
{
    public BitBank bank;
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
        BitBank botBank = bitbot.GetComponent<BitBank>();
        if(botBank.bits > 0)
        {
            BitBank.Transfer(botBank, bank, botBank.bits);
        }
    }
}
