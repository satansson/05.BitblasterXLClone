using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    [SerializeField] GameObject bulletToPool;
    [SerializeField] GameObject[] enemiesToPool;
    [SerializeField] GameObject[] pickUpsToPool;
    List<GameObject> pooledBullets;
    List<GameObject>[] pooledEnemies;
    List<GameObject>[] pooledPickUps;
    public int bulletsAmount, enemiesAmount, pickUpsAmount;
    [SerializeField] Transform bulletsParent, enemiesParent, pickUpsParent;

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
            bullet.transform.parent = bulletsParent;
            pooledBullets.Add(bullet);
        }
    }

    void BuildEnemies()
    {
        for (int i = 0; i < enemiesToPool.Length; i++)
        {
            pooledEnemies[i] = new List<GameObject>(); // initialising each list of the array
            GameObject enemy;

            for (int j = 0; j < enemiesAmount; j++) // pre-instantiating enemies and placing them into initialised list
            {
                enemy = Instantiate(enemiesToPool[i]);
                enemy.SetActive(false);
                enemy.transform.parent = enemiesParent;
                pooledEnemies[i].Add(enemy);
            }
        }
    }

    void BuildPickUps()
    {
        for (int i = 0; i < pickUpsToPool.Length; i++)
        {
            pooledPickUps[i] = new List<GameObject>(); // initialising each list of the array
            GameObject pickUp;

            for (int j = 0; j < pickUpsAmount; j++) // pre-instantiating enemies and placing them into initialised list
            {
                pickUp = Instantiate(pickUpsToPool[i]);
                pickUp.SetActive(false);
                pickUp.transform.parent = pickUpsParent;
                pooledPickUps[i].Add(pickUp);
            }
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

    public GameObject GetPooledEnemy()
    {
        int randEnemy = Random.Range(0, enemiesToPool.Length);

        for (int i = 0; i < enemiesAmount; i++)
        {
            if (!pooledEnemies[randEnemy][i].activeInHierarchy)
                return pooledEnemies[randEnemy][i];
        }
        return null;
    }

    public GameObject GetPooledPickUp()
    {
        int randPickUp = Random.Range(0, pickUpsToPool.Length);

        for (int i = 0; i < pickUpsAmount; i++)
        {
            if (!pooledPickUps[randPickUp][i].activeInHierarchy)
                return pooledPickUps[randPickUp][i];
        }
        return null;
    }
}
