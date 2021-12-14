using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 1.5f, spawnLimit = 0;
    public static int spawned = 0;

    public static EnemySpawner ES;



    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        if (spawned < spawnLimit)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
            spawned++;
            yield return new WaitForSeconds(time);
            StartCoroutine(SpawnAnEnemy());
            Debug.Log("spawned"+spawned);
        }
    }

    public static int getSpawned()
    {
        return spawned;
    }
}
