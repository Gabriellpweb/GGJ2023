using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitSlot : BaseSelectableObject
{
    [SerializeField] private Transform placementPoint;
    private GameObject hostedUnit;

    public bool IsAvailable()
    {
        return hostedUnit == null;
    }
}
