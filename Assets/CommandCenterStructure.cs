using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenterStructure : MonoBehaviour, IInteractable
{
    public BitBank bitBank;
    public EnergyBank energyBank;
    public bool selected;

    public CellController bitCell;
    public CellController energyCell;
    public CellController botCell;

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

    void Update()
    {
        bitCell.TurnOff();
        energyCell.TurnOff();
        botCell.TurnOff();

        if (bitBank.Full())
        {
            bitCell.TurnOn();
        }

        if (energyBank.Full())
        {
            energyCell.TurnOn();
        }
    }

    public void Interact(GameObject bitbot)
    {
        EnergyBank botEnergyBank = bitbot.GetComponent<EnergyBank>();
        EnergyBank.TransferClamped(botEnergyBank, energyBank, botEnergyBank.energy, 0, energyBank.maxEnergy - energyBank.energy);

        BitBank botBitBank = bitbot.GetComponent<BitBank>();
        BitBank.TransferClamped(botBitBank, bitBank, botBitBank.bits, 0, bitBank.maxBits - bitBank.bits);
    }
}
