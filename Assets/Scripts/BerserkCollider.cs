using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkCollider : MonoBehaviour
{
    GameUI gameUI;

    void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            gameUI.UpdateScore(1);
        }
    }
}
