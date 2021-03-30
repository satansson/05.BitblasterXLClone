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
        player = transform.parent.gameObject;
        playerHealth = transform.parent.GetComponent<PlayerHealth>();
        gameUI = FindObjectOfType<GameUI>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage();
        }
        else if (collision.CompareTag("Ammo"))
        {
            gameUI.UpdateShields(1);
        }
        else if (collision.CompareTag("PowerUp"))
        {
            gameUI.UpdateNukes(1);
        }
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        if (pickUpType == "bullets" || pickUpType == "nuke")
    //        {
    //            if (ammoController.pickedUp) // Hides a PickUp object if it's pickedUp
    //            {
    //                collision.GetComponent<AmmoController>().PickUpAmmo(pickUpType, ammoAmount);
    //                gameObject.SetActive(false);
    //            }
    //        }
    //        else
    //            collision.GetComponent<PowerUpController>().ActivatePowerUp(pickUpType);
    //    }
    //}
}
