using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    AmmoController ammoController;
    PowerUpController powerUpController;
    GameUI gameUI;

    void Start()
    {
        player = transform.parent.gameObject;
        playerHealth = transform.parent.GetComponent<PlayerHealth>();
        ammoController = transform.parent.GetComponent<AmmoController>();
        powerUpController = transform.parent.GetComponent<PowerUpController>();
        gameUI = FindObjectOfType<GameUI>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Damages the player +
        {
            playerHealth.TakeDamage();
        }
        else if (collision.CompareTag("Ammo") || collision.CompareTag("PowerUp"))
        {
            PickUpController pickUpController = collision.GetComponent<PickUpController>();
            string pickedUpType = pickUpController.pickUpType;

            if (collision.CompareTag("Ammo")) // Adds Ammo to player +
            {
                int pickedUpAmount = pickUpController.ammoAmount;
                ammoController.PickUpAmmo(pickedUpType, pickedUpAmount);

                if (ammoController.pickedUp)
                {
                    collision.gameObject.SetActive(false);
                }                
            }
            else if (collision.CompareTag("PowerUp")) // Activates powerUp +
            {
                powerUpController.ActivatePowerUp(pickedUpType);
                collision.gameObject.SetActive(false);
            }            
        }
        else if (collision.CompareTag("Shield")) // Adds shield to player +
        {
            gameUI.UpdateShields(1);

            // TODO: pick up only if < 5
            collision.gameObject.SetActive(false);
        }
    }
}
