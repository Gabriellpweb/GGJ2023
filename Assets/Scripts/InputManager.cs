using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonBehaviour<InputManager>
{
    Camera mainCamera;

    ISelectableObject selectedObject;
    ISelectableObject hoverObject;

    void Start()
    {
        DontDestroyOnLoad(this);
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
                Debug.Log($"Selectable found! {selectableObj} ");

                // On mouse click
                if (Input.GetMouseButtonDown(0))
                {
                    if (selectedObject != null && selectedObject != selectableObj)
                    {
                        selectedObject.NoOutline();
                        selectedObject = selectableObj;
                        selectedObject.Select();
                        hoverObject = null;
                    }
                }
                // On mouse hover
                else
                {
                    if (hoverObject != null && selectableObj != hoverObject)
                    {
                        if (hoverObject != null)
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
                if (hoverObject != null)
                {
                    hoverObject.NoOutline();
                    hoverObject = null;
                }
            }
        }

    }
}
