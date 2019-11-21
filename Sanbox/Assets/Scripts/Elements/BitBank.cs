using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitBank : MonoBehaviour
{
    public int bits;
    public int maxBits;

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
}
