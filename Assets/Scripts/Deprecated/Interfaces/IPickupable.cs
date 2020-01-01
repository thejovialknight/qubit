using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    bool IsActive { get; set; }
    void Pickup(GameObject bitbot);
}