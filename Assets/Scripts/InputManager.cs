using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonBehaviour<InputManager>
{
    Camera mainCamera;

    ISelectableObject selectedObject;
    ISelectableObject hoverObject;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.TryGetComponent(out ISelectableObject selectableObj))
            {
                // On mouse click selectableObj
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log($" Mouse click ");

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
