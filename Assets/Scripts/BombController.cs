using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] GameObject enemiesGO, bulletsGO;
    GameUI gameUI;

    void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            IgniteNuke();
        }
    }

    void IgniteNuke()
    {
        if (gameUI.nukesAmount > 0)
        {
            foreach (Transform enemy in enemiesGO.transform)
            {
                if (enemy.gameObject.activeInHierarchy)
                {
                    gameUI.UpdateScore(1);
                    enemy.gameObject.SetActive(false);
                }                
            }
            foreach (Transform bullet in bulletsGO.transform)
            {
                if (bullet.gameObject.activeInHierarchy)
                {
                    bullet.gameObject.SetActive(false);
                }
            }

            gameUI.UpdateNuke(-1);
        }
    }
}
