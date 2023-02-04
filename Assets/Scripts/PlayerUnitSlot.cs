using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitSlot : MonoBehaviour, ISelectableObject, IDeployableObjectHoster
{
    [SerializeField] private Transform placementPoint;
    [SerializeField] private GameObject visualObjectToOutline;
    [SerializeField] private OutlinesSO outlineSO;

    private GameObject hostedUnit;

    private PlayerSlotsManager slotManagerRef;

    public bool IsAvailable()
    {
        return hostedUnit == null;
    }

    public void SubscribeManager(PlayerSlotsManager slotManager)
    {
        slotManagerRef = slotManager;
    }

    public void DeployUnit(GameObject deployableUnit)
    {
        Debug.Log("Trying to deploy");
        if (deployableUnit.TryGetComponent(out IDeployableObject deployable))
        {
            Debug.Log("Trying to instantiate");
            hostedUnit = Instantiate(deployableUnit, placementPoint.position, Quaternion.identity);

            deployable.Deploy(this);
        }
    }

    #region Section and Hover Highligh
    public void Highlight()
    {
        if (!IsAvailable())
        {
            return;
        }
        CanHighlight();
        visualObjectToOutline.layer = LayerMask.NameToLayer(outlineSO.highlightedOutlineLayerName);
    }

    public void Select()
    {
        if (!IsAvailable())
        {
            return;
        }
        CanHighlight();
        visualObjectToOutline.layer = LayerMask.NameToLayer(outlineSO.selectedOutlineLayerName);

        if (slotManagerRef == null)
        {
            Debug.LogError("Slot not subscribed by Slot Manager");
            return;
        }

        slotManagerRef.OpenDeploymentPanel(this);
    }


    public void NoOutline()
    {
        CanHighlight();
        visualObjectToOutline.layer = LayerMask.NameToLayer(outlineSO.noOutlineLayerName);
    }

    public void CanHighlight()
    {
        if (visualObjectToOutline == null)
        {
            Debug.LogError("No Visuals Assigned");
        }

        if (outlineSO == null)
        {
            Debug.LogError("No Outline Assigned");
        }
    }
    #endregion
}
