using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float baseSpawnRate;
    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;
    [SerializeField] float decreaser;
    [SerializeField] int maxX = 960;
    [SerializeField] int maxY = 540;
    [SerializeField] int maxEnemiesAmount;

    public static int enemiesAmount;

    GameUI gameUI;
    float randRate;
    [SerializeField] float spawnRate;

    Vector3 spawnPosition;

    void Start()
    {
        enemiesAmount = 0;
        Invoke("SpawnEnemy", 1);
        gameUI = FindObjectOfType<GameUI>();
    }

    void SpawnEnemy()
    {
        int randomBorder = Random.Range(0, 4);
        int randomXRange = Random.Range(-maxX, maxX);
        int randomYRange = Random.Range(-maxY, maxY);

        randRate = Random.Range(minSpawnTime, maxSpawnTime);
        spawnRate = baseSpawnRate + randRate;

        minSpawnTime -= minSpawnTime * decreaser;
        maxSpawnTime -= maxSpawnTime * decreaser;

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

            if (newEnemy != null)
            {
                newEnemy.transform.position = spawnPosition;
                newEnemy.SetActive(true);
                enemiesAmount++;
                gameUI.UpdateEnemies(enemiesAmount);
            }
            else
            {
                print("There's no enemies to spawn!");
            }            
        }

        Invoke("SpawnEnemy", spawnRate);
    }
}
