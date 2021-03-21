using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] int maxX = 960;
    [SerializeField] int maxY = 540;
    [SerializeField] int maxEnemiesCount;
    [SerializeField] GameObject[] enemyPrefabs;

    int enemiesCount = 0;

    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemyRoutine");
    }

    IEnumerator SpawnEnemyRoutine()
    {
        float randTime = Random.Range(minTime, maxTime);
        float spawnRate = 1 + randTime / Time.time;

        yield return new WaitForSeconds(.5f);

        SpawnEnemy();
        Debug.Log("Enemy was called");
    }

    void SpawnEnemy()
    {
        int randBorder = Random.Range(0, 3);
        int randXRange = Random.Range(-maxX, maxX);
        int randYRange = Random.Range(-maxY, maxY);
        int randEnemy = Random.Range(0, enemyPrefabs.Length);

        if (randBorder == 0)
            spawnPosition = new Vector3(randXRange, maxY, 0);
        else if (randBorder == 1)
            spawnPosition = new Vector3(randXRange, -maxY, 0);
        else if (randBorder == 2)
            spawnPosition = new Vector3(maxX, randYRange, 0);
        else if (randBorder == 3)
            spawnPosition = new Vector3(-maxX, randYRange, 0);

        Instantiate(enemyPrefabs[randEnemy], spawnPosition, enemyPrefabs[randEnemy].transform.rotation);
        enemiesCount++;
        Debug.Log("Enemy was spawned");
    }    
}
