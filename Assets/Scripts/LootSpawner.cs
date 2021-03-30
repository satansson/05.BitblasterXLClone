using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    // TODOs:
    // 1. Spawn random pickUp with some chanse

    [SerializeField] float lootSpawnChanse = .1f;    

    private void OnDisable()
    {
        if (lootSpawnChanse > Random.value)
        {
            PickUpController.SpawnRandomPickUp();
        }
    }
}
