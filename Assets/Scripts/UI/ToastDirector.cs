using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ToastDirector : SingletonBehaviour<ToastDirector>
{

    [SerializeField] private ToastText toastTextPf;
    [SerializeField] private GameObject toastParentContainer;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void CreateToastTextWorldPosition(string text, Vector3 worldPosition)
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(worldPosition);
        ToastText newToast = Instantiate(toastTextPf);
        
        newToast.SetText(text);
        newToast.SetPosition(screenPos);
        
        newToast.transform.SetParent(toastParentContainer.transform);

    }
}
