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
        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);
        SpawnManager.enemiesAmount--;
        gameUI.UpdateEnemies(SpawnManager.enemiesAmount);
        gameUI.UpdateScore(1);
    }
}
