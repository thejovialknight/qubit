using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBankController : MonoBehaviour
{
    // make number gradually change so cells light up from bottom to top

    public EnergyBank bank;

    public List<EnergyBankCellFace> cellFaces = new List<EnergyBankCellFace>();
    public CellController spireCell;

    public float cell2Threshold;
    public float cell3Threshold;

    void Update()
    {
        foreach(EnergyBankCellFace cellFace in cellFaces)
        {
            cellFace.TurnOffCells();
            spireCell.TurnOff();
        }

        if (bank.energy > 0)
        {
            foreach (EnergyBankCellFace cellFace in cellFaces)
            {
                cellFace.TurnOnCell(1);
            }
        }

        if (bank.energy >= bank.maxEnergy * cell2Threshold)
        {
            foreach (EnergyBankCellFace cellFace in cellFaces)
            {
                cellFace.TurnOnCell(2);
            }
        }

        if (bank.energy >= bank.maxEnergy * cell3Threshold)
        {
            foreach (EnergyBankCellFace cellFace in cellFaces)
            {
                cellFace.TurnOnCell(3);
            }
        }

        if (bank.energy >= bank.maxEnergy)
        {
            spireCell.TurnOn();
        }
    }
}
