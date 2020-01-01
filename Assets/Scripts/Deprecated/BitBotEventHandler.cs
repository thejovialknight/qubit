using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitBotEventHandler : MonoBehaviour
{
    public delegate void OnAddEvent(int amount);

    public event OnAddEvent onAddEnergy;
    public void RaiseOnAddEnergy(int amount)
    {
        if (onAddEnergy != null)
        {
            onAddEnergy(amount);
        }
    }

    public event OnAddEvent onAddBits;
    public void RaiseOnAddBits(int amount)
    {
        if (onAddBits != null)
        {
            onAddBits(amount);
        }
    }
}
