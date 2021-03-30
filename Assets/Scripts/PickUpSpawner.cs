using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] float pickUpSpawnChanse;

    private void OnDisable()
    {
        if (pickUpSpawnChanse >= Random.value)
        {
            SpawnRandPickUp();
        }
    }

    void SpawnRandPickUp()
    {
        // TODO: Randomize different pickUp spawn chanses

        GameObject pickUp = ObjectPool.SharedInstance.GetPooledPickUp();
        pickUp.transform.position = gameObject.transform.position;
        pickUp.SetActive(true);
    }
}
