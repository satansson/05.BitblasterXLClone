using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] float basicDuration;
    [SerializeField] bool isPowerUpActive;
    [SerializeField] Multishot multishot;
    [SerializeField] AmmoController ammoController;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject berserkAura;

    float activeUntilTime = 0;
    string powerUpType;

    void FixedUpdate()
    {
        if (isPowerUpActive && Time.time < activeUntilTime)
        {
            if (powerUpType == "multishot")
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    ammoController.shootingAllowed = false;
                    multishot.ShootRepeating();
                }
            }
            else if (powerUpType == "laser")
            {
                ammoController.shootingAllowed = false;
                laser.SetActive(true);
            }
            else if (powerUpType == "berserk")
            {
                berserkAura.SetActive(true);
            }
        }
        else
        {
            if (laser.activeInHierarchy)
            {
                laser.SetActive(false);
            }
            else if (berserkAura.activeInHierarchy)
            {
                berserkAura.SetActive(false);
            }

            powerUpType = null;
            isPowerUpActive = false;
            ammoController.shootingAllowed = true;            
        }        
    }

    public void ActivatePowerUp(string pickedPowerUpType)
    {
        isPowerUpActive = true;
        powerUpType = pickedPowerUpType;
        activeUntilTime = Time.time + basicDuration;
    }
}
