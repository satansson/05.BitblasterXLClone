using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingController : MonoBehaviour
{
    public float shootingSpeed;
    public float bulletSpeed;
    public int ammoAmount;

    public Transform spawnPoint;
    public TextMeshProUGUI ammoText;

    float nextShot = 0;

    private void Start()
    {
        ammoText.text = "Ammo: " + ammoAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightCommand) && Time.time > nextShot && ammoAmount > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        nextShot = Time.time + shootingSpeed;

        GameObject newBullet = ObjectPool.SharedInstance.GetPooledBullet();
        if (newBullet != null)
        {
            newBullet.transform.position = spawnPoint.position;
            newBullet.SetActive(true);
        }

        Rigidbody2D newBulletRB = newBullet.GetComponent<Rigidbody2D>();
        newBulletRB.AddForce(transform.up * bulletSpeed);

        ammoAmount--;
        ammoText.text = "Ammo: " + ammoAmount.ToString();
    }
}
