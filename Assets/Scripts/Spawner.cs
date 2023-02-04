using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float LastSpawn;
    public int spawnRate;
    public GameObject EnemyPreFreb;
    // Start is called before the first frame update
    void Start()
    {
        LastSpawn = 1;
        spawnRate = 1; 
    }

    void spawn()
    {
        Instantiate(EnemyPreFreb, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastSpawn > spawnRate)
        {
            LastSpawn = Time.time;
            spawn();
        }
    }
}
