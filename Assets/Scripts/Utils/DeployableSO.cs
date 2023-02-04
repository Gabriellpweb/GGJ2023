using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deployable Object", menuName = "Custom/Logic/Deployable Object Data")]
public class DeployableSO : ScriptableObject
{
    public GameObject deployableObject;
    public string deployableLabel;
    public Sprite objectIcon;
    public int cost;
}
