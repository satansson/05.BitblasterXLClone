using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float xBorder;
    [SerializeField] float yBorder;
    GameUI gameUI;

    private void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
    }

    private void Update()
    {
        if (transform.position.x > xBorder || transform.position.x < -xBorder || transform.position.y > yBorder || transform.position.y < -yBorder)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            gameUI.UpdateScore(1);
            SpawnManager.enemiesAmount--;
            gameUI.UpdateEnemies(SpawnManager.enemiesAmount);
        }
    }
}
