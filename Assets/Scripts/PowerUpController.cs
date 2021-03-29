using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] float basicDuration;
    [SerializeField] bool isPowerUpActive;
    [SerializeField] Multishot multishot;
    [SerializeField] ShootingController shootingController;

    float activeUntilTime = 0;
    string powerUpType = "multishot";

    // Start is called before the first frame update
    void Start()
    {
        ActivateMultishot();
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
                // TODO: implement laser
            }
        }else{
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
}
