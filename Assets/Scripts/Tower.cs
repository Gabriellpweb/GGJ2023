using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : DamageableObject
{
    public enum TargetPriority
    {
        First,
        Close,
        Strong
    }

    [Header("Info")] 
    private List<Enemy> enemiesInRange = new List<Enemy>();
    private Enemy curEnemy;

    public TargetPriority targetPriority;
    public bool rotateTowardsTarget;

    [Header("Attack")]
    public float attackRate;
    private float lastAttackTime;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPos;

    [Header("Projectile")]
    public int projectileDamage;
    public float projectileSpeed;

    // Update is called once per frame
    void Update()
    {
        // attack every "attackRate" seconds
        if (Time.time - lastAttackTime > attackRate)
        {
            lastAttackTime = Time.time;
            curEnemy = GetEnemy();

            if (curEnemy != null)
                Attack();
        }
    }

    Enemy GetEnemy()
    {
        enemiesInRange.RemoveAll(x => x == null);

        if (enemiesInRange.Count == 0)
            return null;

        if (enemiesInRange.Count == 1)
            return enemiesInRange[0];

        switch (targetPriority)
        {
            case TargetPriority.First:
                {
                    return enemiesInRange[0];
                }
            case TargetPriority.Close:
                {
                    Enemy closest = null;
                    float dist = 100;

                    for (int x = 0; x < enemiesInRange.Count; x++)
                    {
                        float d = Vector3.Distance(transform.position, enemiesInRange[x].transform.position);

                        if (d <= dist)
                        {
                            closest = enemiesInRange[x];
                            dist = d;
                        }
                    }

                    return closest;
                }
            case TargetPriority.Strong:
                {
                    Enemy strongest = null;
                    int strongestHealth = 0;

                    foreach (Enemy enemy in enemiesInRange)
                    {
                        if (enemy.lifePoints > strongestHealth)
                        {
                            strongest = enemy;
                            strongestHealth = enemy.lifePoints;
                        }
                    }

                    return strongest;
                }
        }

        return null;
    }

    // attacks the curEnemy
    void Attack()
    {
        if (rotateTowardsTarget)
        {
            transform.LookAt(curEnemy.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPos.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Initialize(curEnemy, projectileDamage, projectileSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.GetComponent<Enemy>());
        }
    }
}
