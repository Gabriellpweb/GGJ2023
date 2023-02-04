using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageableObject
{

    // Update is called once per frame
    void Update()
    {
        IsItAlive();
    }

    public void TakeDamage(int damage)
    {
        this.lifePoints -= damage;
    }
}
