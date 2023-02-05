using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{

    public int lifePoints = 2;
    public float attackRate = 1;
    public int attackPower = 1;
    protected float lastAttackTime;

    protected GameObject target;

    public event GenericEventHandler OnDie;

    public delegate void GenericEventHandler(object sender, EventArgs e);

    public enum DamageableObjectTypes
    {
        Enemy,
        Player
    }

    public DamageableObjectTypes type;

    public static string getEnemyTag()
    {
        return $"{DamageableObjectTypes.Enemy}";
    }
    public static string getPlayerTag()
    {
        return $"{DamageableObjectTypes.Player}";
    }

    public void TakeDamage(int damage)
    {
        this.lifePoints -= damage;
        IsItAlive();
    }

    

    public bool IsItAlive()
    {
        if (lifePoints <= 0)
        {
            OnDie?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject, 1f);
            return false;
        }

        return true;
    }
}
