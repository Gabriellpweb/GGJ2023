using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : DamageableObject, IDeployableObject
{
    public enum TargetPriority
    {
        First,
        Close,
        Strong
    }


    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioSource audioSource;

    public event GenericEventHandler OnAttack;

    [Header("Info")] 
    private List<EnemyObject> enemiesInRange = new List<EnemyObject>();
    private EnemyObject curEnemy;

    public TargetPriority targetPriority;
    public bool rotateTowardsTarget;

    [Header("Attack")]
    public float attackRange;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPos;

    [Header("Projectile")]
    public float projectileSpeed;

    void Update()
    {
        // attack every "attackRate" seconds
        if (Time.time - lastAttackTime > attackRate)
        {
            lastAttackTime = Time.time;
            curEnemy = GetEnemy();

            if (curEnemy != null && curEnemy.IsItAlive())
                TowerAttack();
        }

        FindEnemiesInRange();
    }

    void FindEnemiesInRange()
    {
        var colliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.GetComponent<EnemyObject>())
            {
                enemiesInRange.Add(collider.gameObject.GetComponent<EnemyObject>());
            }
        }
    }

    EnemyObject GetEnemy()
    {
        enemiesInRange.RemoveAll(x => x == null);

        if (enemiesInRange.Count == 0)
        {
            return null;
        }

        if (enemiesInRange.Count == 1)
        {
            return enemiesInRange[0];
        }

        switch (targetPriority)
        {
            case TargetPriority.First:
                {
                    return enemiesInRange[0];
                }
            case TargetPriority.Close:
                {
                    EnemyObject closest = null;
                    float dist = attackRange;

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
                    EnemyObject strongest = null;
                    int strongestHealth = 0;

                    foreach (EnemyObject enemy in enemiesInRange)
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
    void TowerAttack()
    {
        if (rotateTowardsTarget)
        {
            transform.LookAt(curEnemy.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        OnAttack?.Invoke(this, EventArgs.Empty);
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPos.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Initialize(curEnemy, attackPower, projectileSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //enemiesInRange.Add(other.GetComponent<EnemyObject>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //enemiesInRange.Remove(other.GetComponent<EnemyObject>());
        }
    }


    public void Deploy(IDeployableObjectHoster hosterObject)
    {
        OnDie += hosterObject.UnsubscribeHostedObject;
    }
}
