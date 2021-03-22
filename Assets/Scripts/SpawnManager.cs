using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] int maxX = 960;
    [SerializeField] int maxY = 540;
    [SerializeField] int maxEnemiesAmount;
    [SerializeField] GameObject[] enemyPrefabs;

    int enemiesAmount = 0;

    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", 1);
    }

    void SpawnEnemy()
    {
        int randomBorder = Random.Range(0, 4);
        int randomXRange = Random.Range(-maxX, maxX);
        int randomYRange = Random.Range(-maxY, maxY);
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);

        float randTime = Random.Range(minTime, maxTime);
        float spawnRate = 1 + randTime / Time.time;

        if (randomBorder == 0)
            spawnPosition = new Vector3(randomXRange, maxY, 0);
        else if (randomBorder == 1)
            spawnPosition = new Vector3(randomXRange, -maxY, 0);
        else if (randomBorder == 2)
            spawnPosition = new Vector3(maxX, randomYRange, 0);
        else if (randomBorder == 3)
            spawnPosition = new Vector3(-maxX, randomYRange, 0);

        if (enemiesAmount < maxEnemiesAmount)
        {
            Instantiate(enemyPrefabs[randomEnemy], spawnPosition, enemyPrefabs[randomEnemy].transform.rotation);
            enemiesAmount++;
        }

        Invoke("SpawnEnemy", spawnRate);
    }
}
