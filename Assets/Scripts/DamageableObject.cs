using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    int lifePoints = 10;
    public enum DamageableObjectTypes
    {
        Enemy,
        Player
    }
    public DamageableObjectTypes type;
}
