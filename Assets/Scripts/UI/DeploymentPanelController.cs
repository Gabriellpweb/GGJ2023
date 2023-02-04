using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentPanelController : MonoBehaviour
{
    private DeployableItem[] deployableItems;

    private PlayerUnitSlot selectedSlot;

    public void Open(PlayerUnitSlot slot)
    {
        selectedSlot = slot;
    }


}
