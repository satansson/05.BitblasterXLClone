using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] float spawnChanse;
    [SerializeField] float bulletsValue;
    [SerializeField] float berserkValue;
    [SerializeField] float laserValue;
    [SerializeField] float multishotValue;
    [SerializeField] float nukeValue;

    float randValue;
    int pichUpIndex;

    private void OnDisable()
    {
        if (ObjectPool.SharedInstance.enemiesSpawned)
        {
            if (spawnChanse >= Random.value)
            {
                SpawnRandPickUp();
            }
        }        
    }

    void SpawnRandPickUp()
    {
        randValue = Random.value;

        // Splitting the '0.0f-1.0f' interval to six pieces, each for a certain pickUp index 
        if (randValue >= 0 && randValue < bulletsValue)
        {
            pichUpIndex = 0; // pickUp = bullets
        }
        else if (randValue >= bulletsValue && randValue < berserkValue)
        {
            pichUpIndex = 1; // pickUp = berserk
        }
        else if (randValue >= berserkValue && randValue < laserValue)
        {
            pichUpIndex = 2; // pickUp = laser
        }
        else if (randValue >= laserValue && randValue < multishotValue)
        {
            pichUpIndex = 3; // pickUp = multishot
        }
        else if (randValue >= multishotValue && randValue <= nukeValue)
        {
            pichUpIndex = 4; // pickUp = nuke
        }
        else
        {
            pichUpIndex = 5; // pickUp = shield
        }

        GameObject pickUp = ObjectPool.SharedInstance.GetPooledPickUp(pichUpIndex);
        pickUp.transform.position = gameObject.transform.position;
        pickUp.SetActive(true);
    }
}
