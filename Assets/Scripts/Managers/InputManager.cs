using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonBehaviour<InputManager>
{
    public LayerMask selectableLayer;
    public const string SELECTABLE_LAYER = "Selectable";

    private Camera mainCamera;

    private ISelectableObject selectedObject;
    private ISelectableObject hoverObject;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer(SELECTABLE_LAYER)))
        {
            Transform objectHit = hit.transform;

            if (objectHit.TryGetComponent(out ISelectableObject selectableObj))
            {
                
                // On mouse click selectableObj
                if (Input.GetMouseButtonDown(0))
                {

                    if (selectedObject != selectableObj)
                    {
                        if (selectedObject != null)
                        {
                            selectedObject.NoOutline();
                            hoverObject = null;
                        }
                        selectedObject = selectableObj;
                        selectedObject.Select();
                    }
                }
                // On mouse hover selectableObj
                else
                {
                    // Hover
                    if (!Input.GetMouseButtonDown(0))
                    {
                        if (selectableObj != hoverObject && selectableObj != selectedObject)
                        {
                            if (hoverObject != null && hoverObject != selectedObject)
                            {
                                hoverObject.NoOutline();
                            }
                            hoverObject = selectableObj;
                            hoverObject.Highlight();
                        }
                    }
                }
            }
            else
            {
                if (hoverObject != null && hoverObject != selectedObject)
                {
                    hoverObject.NoOutline();
                    hoverObject = null;
                }
            }
        }

    }
}
