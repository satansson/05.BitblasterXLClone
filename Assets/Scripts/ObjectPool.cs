using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public GameObject bulletToPool;
    public GameObject[] enemiesToPool;
    public List<GameObject> pooledBullets;
    public List<GameObject>[] pooledEnemies;
    public int bulletsAmount, enemiesAmount;
    [SerializeField] Transform bullets, enemies;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledEnemies = new List<GameObject>[enemiesToPool.Length]; // initializing of the array of lists with the amount of enemy types :)
        BuildBullets();
        BuildEnemies();
    }

    void BuildBullets()
    {
        pooledBullets = new List<GameObject>();
        GameObject bullet;

        for (int i = 0; i < bulletsAmount; i++) // pre-instantiating bullets and placing them into the list
        {
            bullet = Instantiate(bulletToPool);
            bullet.SetActive(false);
            bullet.transform.parent = bullets;
            pooledBullets.Add(bullet);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < bulletsAmount; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
                return pooledBullets[i]; // get a bullet from the list
        }
        return null;
    }

    void BuildEnemies()
    {
        for (int i = 0; i < enemiesToPool.Length; i++)
        {
            pooledEnemies[i] = new List<GameObject>(); // initializing of each list in the array
            GameObject enemy;

            for (int j = 0; j < enemiesAmount; j++) // pre-instantiating enemies and placing them into corresponding lists
            {
                enemy = Instantiate(enemiesToPool[i]);
                enemy.SetActive(false);
                enemy.transform.parent = enemies;
                pooledEnemies[i].Add(enemy);
            }
        }
    }

    public GameObject GetPooledEnemy()
    {
        int randomEnemy = Random.Range(0, enemiesToPool.Length);

        for (int i = 0; i < enemiesAmount; i++)
        {
            if (!pooledEnemies[randomEnemy][i].activeInHierarchy)
                return pooledEnemies[randomEnemy][i];
        }
        return null;
    }
}
