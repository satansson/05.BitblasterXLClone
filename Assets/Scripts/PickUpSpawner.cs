using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] float pickUpSpawnChanse = .1f;

    private void OnDisable()
    {
        if (pickUpSpawnChanse >= Random.value)
        {
            SpawnRandPickUp();
        }
    }

    void SpawnRandPickUp()
    {
        GameObject pickUp = ObjectPool.SharedInstance.GetPooledPickUp();
        pickUp.transform.position = gameObject.transform.position;
        pickUp.SetActive(true);
    }
}
