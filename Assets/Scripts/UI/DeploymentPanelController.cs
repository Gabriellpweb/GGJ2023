using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeploymentPanelController : MonoBehaviour
{
    [SerializeField] private DeployableItem deployableItemPf;

    private List<DeployableItem> deployableItems;

    private PlayerUnitSlot selectedSlot;

    private void Awake()
    {
        deployableItems = new List<DeployableItem>();
    }

    /// <summary>
    /// Clean and re-populate deployables list
    /// </summary>
    /// <param name="deployables"></param>
    public void SetDeployables(DeployableSO[] deployables)
    {
        Clean();
        foreach (DeployableSO deployableSO in deployables)
        {
            // Mount deployableItem
            DeployableItem newDeployableItem = Instantiate(deployableItemPf);
            newDeployableItem.thumb.sprite = deployableSO.objectIcon;
            newDeployableItem.textMesh.text = deployableSO.deployableLabel;
            newDeployableItem.button.onClick.AddListener(delegate { DeployUnit(deployableSO); });

            // Attach to parent and include reference to list
            newDeployableItem.transform.SetParent(transform);
            deployableItems.Add(newDeployableItem);
        }
    }

    private void Clean()
    {
        foreach (DeployableItem deployableItem in deployableItems)
        {
            deployableItem.thumb.sprite = null;
            deployableItem.textMesh.text = null;
            deployableItem.button.onClick.RemoveAllListeners();
            Destroy(deployableItem.gameObject);
        }
        deployableItems.Clear();
    }
    public void Open(PlayerUnitSlot slot)
    {
        selectedSlot = slot;
    }

    public void Close()
    {
        Clean();
        selectedSlot = null;
        gameObject.SetActive(false);
    }

    public void DeployUnit(DeployableSO deployableSO)
    {
        Debug.Log($"Deploy {deployableSO.deployableLabel}");
        selectedSlot.DeployUnit(deployableSO.deployableObject);
        Close();
    }

}
