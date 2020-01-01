using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitPickup : MonoBehaviour, IPickupable
{
    public PickupInfo info;
    Animator animator;
    public AudioClip pickupSound;

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
        animator = GetComponent<Animator>();
    }

    public void Pickup(GameObject bitbot)
    {
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        bitbot.GetComponent<BitBank>().Deposit(info.value);
        animator.SetBool("Destroy", true);
        IsActive = false;
    }
}
