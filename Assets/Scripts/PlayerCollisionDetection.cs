using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    GameUI gameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (gameUI.shieldsAmount > 0)
            {
                gameUI.UpdateShields(-1);
            }
            else
            {
                // TODO: GameOver
            }
        }
        else if (collision.CompareTag("Shield"))
        {
            gameUI.UpdateShields(1);
        }
        else if (collision.CompareTag("Nuke"))
        {
            gameUI.UpdateNuke(1);
        }
    }
}
