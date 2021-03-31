using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    [SerializeField] GameObject bulletToPool;
    [SerializeField] GameObject[] enemiesToPool;
    [SerializeField] GameObject[] pickUpsToPool;
    [SerializeField] Transform bulletsParent, enemiesParent, pickUpsParent;
    List<GameObject> pooledBullets;
    List<GameObject>[] pooledEnemies;
    List<GameObject>[] pooledPickUps;

    public int bulletsAmount, enemiesAmount, pickUpAmount;

    public bool enemiesSpawned;

    private void Awake()
    {
        SharedInstance = this;

        pooledEnemies = new List<GameObject>[enemiesToPool.Length]; // initializes an array of enemy lists :)
        pooledPickUps = new List<GameObject>[pickUpsToPool.Length]; // initializes an array of pickUp lists :)

        BuildBullets();
        BuildPickUps();
        BuildEnemies();
    }

    // Bullets pre-instantiating
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

    // PickUps pre-instantiating
    void BuildPickUps()
    {
        for (int i = 0; i < pickUpsToPool.Length; i++)
        {
            pooledPickUps[i] = new List<GameObject>(); // initialising each list in the array
            GameObject pickUp;

            for (int j = 0; j < pickUpAmount; j++) // pre-instantiating enemies and placing them into initialised list
            {
                pickUp = Instantiate(pickUpsToPool[i]);
                pickUp.SetActive(false);
                pickUp.transform.parent = pickUpsParent;
                pooledPickUps[i].Add(pickUp);
            }
        }
    }

    // Enemies pre-instantiating
    void BuildEnemies()
    {
        for (int i = 0; i < enemiesToPool.Length; i++)
        {
            pooledEnemies[i] = new List<GameObject>(); // initialising each list in the array
            GameObject enemy;

            for (int j = 0; j < enemiesAmount; j++) // pre-instantiating enemies and placing them into initialised list
            {
                enemy = Instantiate(enemiesToPool[i]);
                enemy.SetActive(false);
                enemy.transform.parent = enemiesParent;
                pooledEnemies[i].Add(enemy);
            }
        }

        enemiesSpawned = true;
    }

    // Returns a player bullet
    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < bulletsAmount; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
                return pooledBullets[i];
        }
        return null;
    }

    // Returns a random enemy
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

    // Returns a certain pickUp
    public GameObject GetPooledPickUp(int index)
    {
        for (int i = 0; i < pickUpAmount; i++)
        {
            if (!pooledPickUps[index][i].activeInHierarchy)
                return pooledPickUps[index][i];
        }
        return null;
    }
}
