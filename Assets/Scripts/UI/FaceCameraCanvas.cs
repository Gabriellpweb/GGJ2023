using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCameraCanvas : MonoBehaviour
{
    public Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(cameraTransform.position);
        Quaternion cameraForwardForOrient = Quaternion.Euler(transform.rotation.eulerAngles.x, Quaternion.LookRotation(-cameraTransform.forward).eulerAngles.y, 0);
        transform.rotation = cameraForwardForOrient;
    }
}
