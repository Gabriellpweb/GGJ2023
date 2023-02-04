using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemy target;
    private int projectileDamage;
    private float projectileSpeed;

    public GameObject hitSpawnPrefab;

    public void Initialize(Enemy target, int projectileDamage, float projectileSpeed)
    {
        this.target = target;
        this.projectileDamage = projectileDamage;
        this.projectileSpeed = projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, projectileSpeed * Time.deltaTime);

            transform.LookAt(target.transform);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.2f)
            {
                target.TakeDamage(projectileDamage);

                if (hitSpawnPrefab != null)
                    Instantiate(hitSpawnPrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
