using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{

    public int lifePoints = 2;
    public float attackRate = 1;
    public int attackPower = 1;
    float lastAttackTime;

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

    public void TakeDamage(int damage)
    {
        this.lifePoints -= damage;
    }

    protected void Attack()
    {
       
        if (target == null) { //there is no target, nothing to do here
            //Debug.Log("Attack method target NULL");
            return;
        }
       
        if (Time.time - lastAttackTime > attackRate) {
            lastAttackTime = Time.time;
            DamageableObject damageableComp = target.GetComponent<DamageableObject>();
            damageableComp.TakeDamage(attackPower);
            Debug.Log($"Attacked HP {damageableComp.lifePoints}");
            damageableComp.IsItAlive();
        }
    }

    public bool IsItAlive()
    {
        if (lifePoints <= 0)
        {
            Destroy(gameObject);
            return false;
        }

        return true;
    }

    void Update()
    {
        IsItAlive();
    }
}
