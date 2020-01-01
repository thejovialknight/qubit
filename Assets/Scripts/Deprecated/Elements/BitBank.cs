using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitBank : MonoBehaviour
{
    public int bits;
    public int maxBits;

    public bool Full()
    {
        if(bits < maxBits)
        {
            return false;
        }
        return true;
    }

    public void Deposit(int amount)
    {
        bits += amount;
    }

    public void Withdraw(int amount)
    {
        bits -= amount;
    }

    public static void Transfer(BitBank sender, BitBank reciever, int amount)
    {
        if (sender.bits >= amount)
        {
            reciever.Deposit(amount);
            sender.Withdraw(amount);
        }
        else
        {
            Debug.Log("Sender doesn't have enough money for transfer!");
        }
    }

    public static void TransferClamped(BitBank sender, BitBank reciever, int amount, int min, int max)
    {
        Transfer(sender, reciever, Mathf.Clamp(amount, min, max));
    }
}
