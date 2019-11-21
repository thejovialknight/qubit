using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBankController : MonoBehaviour
{
    public BitBank bank;
    public CellController spireCell;

    void Update()
    {
        if (bank.bits >= bank.maxBits)
        {
            spireCell.TurnOn();
        }
    }
}
