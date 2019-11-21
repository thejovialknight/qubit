using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitPickup : MonoBehaviour, IPickupable
{
    public PickupInfo info;

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

    public void Awake()
    {
        info = GetComponent<PickupInfo>();
    }

    public void Pickup(GameObject bitbot)
    {
        bitbot.GetComponent<BitBank>().Deposit(info.value);
        GetComponent<ShrinkAndDestroy>().StartCoroutine("Destroy");
        IsActive = false;
    }
}
