using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI enemiesText;
    public TextMeshProUGUI scoreText;
    [SerializeField] Color green, red;
    [SerializeField] GameObject[] shieldSprites;
    [SerializeField] GameObject[] nukeSprites;

    public int shieldAmount = 5;
    public int nukeAmount = 5;
    int score = 0;

    private void Start()
    {
        green = ammoText.color;
    }

    public void UpdateAmmo(int ammo)
    {
        ammoText.text = "Ammo: " + ammo.ToString();

        if (ammo == 0)
        {
            ChangeAmmoTextColor(true);
        }
    }

    public void UpdateEnemies(int enemies)
    {
        enemiesText.text = "Enemies: " + enemies.ToString();
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }

    public void ChangeAmmoTextColor(bool isEmpty)
    {
        ammoText.color = isEmpty ? red : green;
    }

    public void UpdateShields(int change)
    {
        if (change > 0 && shieldAmount < 5)
        {
            shieldAmount += change;
            shieldSprites[shieldAmount - 1].SetActive(true);
        }
        else if (change < 0 && shieldAmount > 0)
        {
            shieldSprites[shieldAmount - 1].SetActive(false);
            shieldAmount += change;
        }
    }

    public void UpdateNuke(int change)
    {
        if (change > 0 && shieldAmount < 5)
        {
            nukeAmount++;
            nukeSprites[nukeAmount - 1].SetActive(true);
        }
        else if (change < 0 && shieldAmount > 0)
        {
            nukeSprites[nukeAmount - 1].SetActive(false);
            nukeAmount--;
        }        
    }
}
