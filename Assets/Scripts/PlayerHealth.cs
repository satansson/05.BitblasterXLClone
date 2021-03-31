using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{    
    [SerializeField] GameObject shipSprite;
    [SerializeField] float invincibilityTime;

    GameUI gameUI;
    bool isInvincible;
    public static bool gameOver;

    void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
    }

    public void TakeDamage()
    {
        if (!isInvincible)
        {
            if (gameUI.shieldAmount > 0)
            {
                gameUI.UpdateShields(-1);
                StartCoroutine(DamageBlinker());
            }
            else
            {
                DestroyShip();
            }
        }
    }

    public void DestroyShip()
    {
        gameOver = true;
        gameObject.SetActive(false);

        if (gameUI.score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", gameUI.score);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    IEnumerator DamageBlinker()
    {
        isInvincible = true;
        float invTime = invincibilityTime / 8;

        for (int i = 0; i < 4; i++)
        {
            shipSprite.SetActive(false);
            yield return new WaitForSeconds(invTime);
            shipSprite.SetActive(true);
            yield return new WaitForSeconds(invTime);
        }

        isInvincible = false;
    }
}
