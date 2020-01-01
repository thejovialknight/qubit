using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBankController : MonoBehaviour
{
    float count = 0;

    public EnergyBank bank;
    public int energyCount;
    public float countSpeed = 0.05f;

    public List<EnergyBankCellFace> cellFaces = new List<EnergyBankCellFace>();
    public CellController spireCell;

    public float cell2Threshold;
    public float cell3Threshold;

    void Update()
    {
        count -= Time.deltaTime;
        if(count < 0)
        {
            if(energyCount < bank.energy)
            {
                energyCount += 1;
            }

            if (energyCount > bank.energy)
            {
                energyCount -= 1;
            }

            count = countSpeed;
        }

        foreach (EnergyBankCellFace cellFace in cellFaces)
        {
            cellFace.TurnOffCells();
            spireCell.TurnOff();
        }

        if (energyCount > 0)
        {
            foreach (EnergyBankCellFace cellFace in cellFaces)
            {
                cellFace.TurnOnCell(1);
            }
        }

        if (energyCount >= bank.maxEnergy * cell2Threshold)
        {
            foreach (EnergyBankCellFace cellFace in cellFaces)
            {
                cellFace.TurnOnCell(2);
            }
        }

        if (energyCount >= bank.maxEnergy * cell3Threshold)
        {
            foreach (EnergyBankCellFace cellFace in cellFaces)
            {
                cellFace.TurnOnCell(3);
            }
        }

        if (energyCount >= bank.maxEnergy)
        {
            spireCell.TurnOn();
        }
    }
}
