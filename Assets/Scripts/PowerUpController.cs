using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] float basicDuration;
    [SerializeField] bool isPowerUpActive;
    [SerializeField] Multishot multishot;
    [SerializeField] ShootingController shootingController;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject berserkAura;

    float activeUntilTime = 0;
    string powerUpType = "multishot";

    // Start is called before the first frame update
    void Start()
    {
        ActivateBerserk();
    }

    void Update()
    {
        if (isPowerUpActive && Time.time < activeUntilTime)
        {
            shootingController.enabled = false;

            if (powerUpType == "multishot")
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    multishot.ShootRepeating();
                }
            }
            else if (powerUpType == "laser")
            {
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
            shootingController.enabled = true;            
        }        
    }

    public void ActivateMultishot()
    {
        isPowerUpActive = true;
        powerUpType = "multishot";
        activeUntilTime = Time.time + basicDuration;
    }

    public void ActivateLaser()
    {
        isPowerUpActive = true;
        powerUpType = "laser";
        activeUntilTime = Time.time + basicDuration;
    }

    public void ActivateBerserk()
    {
        isPowerUpActive = true;
        powerUpType = "berserk";
        activeUntilTime = Time.time + basicDuration;
    }
}
