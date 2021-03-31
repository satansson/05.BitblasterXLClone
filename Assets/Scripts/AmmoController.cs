using UnityEngine;

public class AmmoController : MonoBehaviour
{
    [SerializeField] GameObject enemiesParent, bulletsParent;
    [SerializeField] int bulletAmount;
    [SerializeField] Transform spawnPoint;

    public float shootingSpeed;
    public float bulletSpeed;
    public bool shootingAllowed = true;
    public bool pickedUp;

    GameUI gameUI;

    float nextShot = 0;    

    private void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
        gameUI.UpdateBullets(bulletAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextShot)
        {
            if (shootingAllowed && bulletAmount > 0)
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && gameUI.nukeAmount > 0)
        {
            IgniteNuke();
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

        bulletAmount--;
        gameUI.UpdateBullets(bulletAmount);
    }

    void IgniteNuke()
    {
        // Destroyes all the enemies
        foreach (Transform enemy in enemiesParent.transform)
        {
            if (enemy.gameObject.activeInHierarchy)
            {
                enemy.gameObject.SetActive(false);
                gameUI.UpdateScore(1);
                SpawnManager.enemiesAmount--;
                gameUI.UpdateEnemies(SpawnManager.enemiesAmount);
            }
        }
        // Destroyes all the bullets
        foreach (Transform bullet in bulletsParent.transform)
        {
            if (bullet.gameObject.activeInHierarchy)
            {
                bullet.gameObject.SetActive(false);
            }
        }

        gameUI.UpdateNukes(-1); 
    }

    public void PickUpAmmo(string ammoType, int plusAmount)
    {
        if (ammoType == "bullets")
        {
            bulletAmount += plusAmount;
            gameUI.UpdateBullets(bulletAmount);
            pickedUp = true;
        }
        else
        {
            if (gameUI.nukeAmount < 5)
            {
                gameUI.nukeAmount += plusAmount;
                gameUI.UpdateNukes(plusAmount);
                pickedUp = true;
            }
            else
            {
                pickedUp = false;
            }            
        }
    }
}
