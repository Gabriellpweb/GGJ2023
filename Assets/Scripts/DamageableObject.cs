using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    public int lifePoints = 10;
    float lastAttackTime;
    float updateInterval = 0.5F;
    int attackRate = 1;

    protected GameObject target;

    public enum DamageableObjectTypes
    {
        Enemy,
        Player
    }

    public DamageableObjectTypes type;

    public static string getPlayerTag()
    {
        return $"{DamageableObjectTypes.Player}";
    }

    void Attack()
    {
       
        if (target == null) { //there is no target, nothing to do here
            Debug.Log("Attack method target NULL");
            return;
        }
        Debug.Log("Attack method w/ target");
        float currentTime = Time.time;

        if (lastAttackTime == null || (currentTime - lastAttackTime > attackRate)) {
            lastAttackTime = currentTime;
            DamageableObject damageableComp = target.GetComponent<DamageableObject>();
            Debug.Log("VAI MORRE!! VAI MORRE!");
        }
    }

    void IsItAlive()
    {
        if (lifePoints <= 0)
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        IsItAlive();
        Attack();
    }
}
