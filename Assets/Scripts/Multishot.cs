using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multishot : MonoBehaviour
{
    public Transform[] spawnPoints;
    float shootingSpeed;
    float bulletSpeed;
    float nextShot = 0;

    AmmoController ammoController;

    void Start()
    {
        ammoController = GetComponent<AmmoController>();
        shootingSpeed = ammoController.shootingSpeed / 2;
        bulletSpeed = ammoController.bulletSpeed;
    }

    public void ShootRepeating()
    {
        if (Time.time > nextShot + shootingSpeed)
        {
            foreach (Transform spawnpoint in spawnPoints)
            {
                GameObject newBullet = ObjectPool.SharedInstance.GetPooledBullet();
                if (newBullet != null)
                {
                    newBullet.transform.position = spawnpoint.position;
                    newBullet.SetActive(true);
                }

                Vector2 dir = (spawnpoint.position - gameObject.transform.position).normalized;
                Rigidbody2D newBulletRB = newBullet.GetComponent<Rigidbody2D>();
                newBulletRB.AddForce(dir * bulletSpeed);

                nextShot = Time.time + shootingSpeed;
            }
        }
    }
}
