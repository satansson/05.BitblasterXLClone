using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    GameUI gameUI;

    void Start()
    {
        player = gameObject;
        playerHealth = GetComponent<PlayerHealth>();
        gameUI = FindObjectOfType<GameUI>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage();
        }
        //else if (collision.CompareTag("ShieldPickup"))
        //{
        //    gameUI.UpdateShields(1);
        //}
        //else if (collision.CompareTag("NukePickup"))
        //{
        //    gameUI.UpdateNuke(1);
        //}
    }
}
