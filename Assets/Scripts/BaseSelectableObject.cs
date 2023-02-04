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
        visualObjectToOutline.layer = outlineSO.highlightedOutlineLayer.value;
    }

    public void Select()
    {
        Validate();
        visualObjectToOutline.layer = outlineSO.selectedOutlineLayer.value;
    }


    public void NoOutline()
    {
        Validate();
        visualObjectToOutline.layer = outlineSO.noOutlineLayer.value;
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
