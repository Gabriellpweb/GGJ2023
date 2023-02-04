using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Outline Layers", menuName = "Custom/Visuals/Outline Layer Data")]
public class OutlinesSO : ScriptableObject
{
    public string selectedOutlineLayerName;
    public string highlightedOutlineLayerName;
    public string noOutlineLayerName;
}
