using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSelectableObject : MonoBehaviour, ISelectableObject
{
    [SerializeField] private GameObject visualObjectToOutline;
    [SerializeField] private OutlinesSO outlineSO;

    public void Highlight()
    {
        Validate();
        visualObjectToOutline.layer = LayerMask.NameToLayer(outlineSO.highlightedOutlineLayerName);
    }

    public void Select()
    {
        Validate();
        visualObjectToOutline.layer = LayerMask.NameToLayer(outlineSO.selectedOutlineLayerName);
    }


    public void NoOutline()
    {
        Validate();
        visualObjectToOutline.layer = LayerMask.NameToLayer(outlineSO.noOutlineLayerName);
    }

    public void Validate()
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
