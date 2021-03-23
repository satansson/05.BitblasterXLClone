using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public float shootingSpeed;
    public float bulletSpeed;
    public int ammoAmount;
    public Transform spawnPoint;
    GameUI gameUI;

    float nextShot = 0;

    private void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
        gameUI.UpdateAmmo(ammoAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextShot && ammoAmount > 0)
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

        if (ammoAmount == 0)
        {
            gameUI.ChangeAmmoTextColor(true);
        }

        gameUI.UpdateAmmo(ammoAmount);
    }
}
