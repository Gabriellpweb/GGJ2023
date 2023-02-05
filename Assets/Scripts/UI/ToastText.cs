using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToastText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    public void SetPosition(Vector3 screenPosition)
    {
        transform.position = screenPosition;
        transform.localPosition = screenPosition;
    }

    public void SetText(string text)
    {
        textMesh.text = text;
    }
}
