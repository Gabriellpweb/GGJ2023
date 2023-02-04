using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlotsManager : SingletonBehaviour<PlayerSlotsManager>
{
    [SerializeField] private List<DeployableSO> deployables;

    [SerializeField] private DeploymentPanelController deploymentController;

    private PlayerUnitSlot[] playerSlots;

    void Start()
    {
        playerSlots = FindObjectsByType<PlayerUnitSlot>(FindObjectsSortMode.None);
    }

    public DeployableSO[] GetDeployables()
    {
        return deployables.ToArray();
    }
}
