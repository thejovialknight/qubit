using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    bool IsActive { get; set; }
    void Select();
    void Deselect();
}
