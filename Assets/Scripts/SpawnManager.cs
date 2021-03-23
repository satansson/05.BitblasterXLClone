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

    public static int enemiesAmount = 0;

    Vector3 spawnPosition;

    void Start()
    {
        Invoke("SpawnEnemy", 1);
    }

    void SpawnEnemy()
    {
        int randomBorder = Random.Range(0, 4);
        int randomXRange = Random.Range(-maxX, maxX);
        int randomYRange = Random.Range(-maxY, maxY);

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
            GameObject newEnemy = ObjectPool.SharedInstance.GetPooledEnemy();
            newEnemy.transform.position = spawnPosition;
            newEnemy.SetActive(true);
            enemiesAmount++;
        }

        Invoke("SpawnEnemy", spawnRate);
    }
}
