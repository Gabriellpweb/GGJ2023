using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageableObject
{

    // Update is called once per frame
    void Update()
    {
        if (this.lifePoints == 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        this.lifePoints -= damage;
    }
}
