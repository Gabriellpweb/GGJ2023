using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Outline Layers", menuName = "Custom/Visuals/Outline Layer Data")]
public class OutlinesSO : ScriptableObject
{
    [SerializeField] public LayerMask selectedOutlineLayer;
    [SerializeField] public LayerMask highlightedOutlineLayer;
    [SerializeField] public LayerMask noOutlineLayer;
}
