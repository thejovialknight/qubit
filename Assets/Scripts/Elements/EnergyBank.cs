using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBank : MonoBehaviour
{
    public int energy;
    public int maxEnergy;

    public bool Full()
    {
        if(energy < maxEnergy)
        {
            return false;
        }
        return true;
    }

    public void Deposit(int amount)
    {
        energy += amount;
    }

    public void Withdraw(int amount)
    {
        energy -= amount;
    }

    public static void Transfer(EnergyBank sender, EnergyBank reciever, int amount)
    {
        if (sender.energy >= amount)
        {
            reciever.Deposit(amount);
            sender.Withdraw(amount);
        }
        else
        {
            Debug.Log("Sender doesn't have enough money for transfer!");
        }
    }

    public static void TransferClamped(EnergyBank sender, EnergyBank reciever, int amount, int min, int max)
    {
        Transfer(sender, reciever, Mathf.Clamp(amount, min, max));
    }
}
