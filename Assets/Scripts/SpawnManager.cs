using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] int maxX = 960;
    [SerializeField] int maxY = 540;
    [SerializeField] int maxEnemiesAmount;
    GameUI gameUI;

    public static int enemiesAmount = 0;

    Vector3 spawnPosition;

    void Start()
    {
        Invoke("SpawnEnemy", 1);
        gameUI = FindObjectOfType<GameUI>();
    }

    void SpawnEnemy()
    {
        int randomBorder = Random.Range(0, 4);
        int randomXRange = Random.Range(-maxX, maxX);
        int randomYRange = Random.Range(-maxY, maxY);

        float randTime = Random.Range(minTime, maxTime / Time.time);
        float spawnRate = .5f + randTime;

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
