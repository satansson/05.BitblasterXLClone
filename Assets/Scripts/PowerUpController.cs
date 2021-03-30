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
    string powerUpType = "multishot";

    // Start is called before the first frame update
    void Start()
    {
        //ActivatePowerUp(powerUpType);
    }

    void Update()
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
            if (powerUpType == "laser")
            {
                laser.SetActive(false);
            }
            else if (powerUpType == "berserk")
            {
                berserkAura.SetActive(false);
            }

            powerUpType = null;
            isPowerUpActive = false;
            ammoController.shootingAllowed = true;            
        }        
    }

    public void ActivatePowerUp(string _powerUpType)
    {
        isPowerUpActive = true;
        powerUpType = _powerUpType;
        activeUntilTime = Time.time + basicDuration;
    }
}
