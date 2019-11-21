using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : MonoBehaviour, IPickupable
{
    PickupInfo info;

    public bool isActive = true;
    public bool IsActive
    {
        get
        {
            return isActive;
        }

        set
        {
            isActive = value;
        }
    }

    void Awake()
    {
        info = GetComponent<PickupInfo>();
    }

    public void Pickup(GameObject bitbot)
    {
        bitbot.GetComponent<EnergyBank>().Deposit(info.value);
        GetComponent<ShrinkAndDestroy>().StartCoroutine("Destroy");
        IsActive = false;
    }
}
