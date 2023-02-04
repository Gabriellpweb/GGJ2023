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
        foreach (PlayerUnitSlot playerSlot in playerSlots)
        {
            playerSlot.SubscribeManager(this);
        }
    }

    public DeployableSO[] GetDeployables()
    {
        return deployables.ToArray();
    }

    public void OpenDeploymentPanel(PlayerUnitSlot slot)
    {
        deploymentController.gameObject.SetActive(true);
        deploymentController.SetDeployables(deployables.ToArray());
        deploymentController.Open(slot);
    }
}
