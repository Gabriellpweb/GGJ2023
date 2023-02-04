using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitSlot : MonoBehaviour, ISelectableObject
{
    [SerializeField] private Transform placementPoint;
    [SerializeField] private GameObject visualObjectToOutline;
    [SerializeField] private OutlinesSO outlineSO;

    private GameObject hostedUnit;

    public bool IsAvailable()
    {
        return hostedUnit == null;
    }

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
}
