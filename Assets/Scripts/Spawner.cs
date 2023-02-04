using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float LastSpawn;
    public int spawnRate;
    public GameObject EnemyPreFreb;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        LastSpawn = 1;
        spawnRate = 10; // decrease to increase the amount of monsters
        GameObject timerObject = GameObject.Find("TIMER");
        timer = timerObject.GetComponent<Timer>();
    }

    float getSpawnRate(float n)
    {
        return spawnRate / (10 - n);
    }

    void spawn()
    {
        Instantiate(EnemyPreFreb, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastSpawn > getSpawnRate(timer.minute))
        {
            LastSpawn = Time.time;
            spawn();
        }
    }
}
