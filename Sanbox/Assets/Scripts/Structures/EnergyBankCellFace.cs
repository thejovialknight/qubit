using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBankCellFace : MonoBehaviour
{
    public CellController cell1;
    public CellController cell2;
    public CellController cell3;

    public void TurnOnCell(int cell)
    {
        TurnOffCells();

        if (cell == 3)
        {
            cell3.TurnOn();
            cell2.TurnOn();
            cell1.TurnOn();
        }
        else if (cell == 2)
        {
            cell2.TurnOn();
            cell1.TurnOn();
        }
        else if (cell == 1)
        {
            cell1.TurnOn();
        }
    }

    public void TurnOffCells()
    {
        cell1.TurnOff();
        cell2.TurnOff();
        cell3.TurnOff();
    }
}
