using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI bulletsText;
    public TextMeshProUGUI enemiesText;
    public TextMeshProUGUI scoreText;
    [SerializeField] Color green, red;
    [SerializeField] GameObject[] shieldSprites;
    [SerializeField] GameObject[] nukeSprites;

    public int nukeAmount = 5;
    public int shieldAmount = 5;
    public bool pickedUp;
    public int score = 0;

    private void Start()
    {
        green = bulletsText.color;
    }

    public void UpdateBullets(int _bulletAmount)
    {
        bulletsText.text = "Bullets: " + _bulletAmount.ToString();

        if (_bulletAmount == 0)
        {
            ChangeBulletsTextColor(true);
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

    public void ChangeBulletsTextColor(bool isEmpty)
    {
        bulletsText.color = isEmpty ? red : green;
    }

    public void UpdateShields(int shieldUpdate)
    {
        if (shieldUpdate > 0 && shieldAmount < 5)
        {
            shieldAmount += shieldUpdate;
            shieldSprites[shieldAmount - 1].SetActive(true);
            pickedUp = true;
        }
        else if (shieldUpdate < 0 && shieldAmount > 0)
        {
            shieldSprites[shieldAmount - 1].SetActive(false);
            shieldAmount += shieldUpdate;
        }
        else
            pickedUp = false;
    }

    public void UpdateNukes(int nukeUpdate)
    {
        // Shows a corresponding nuke icon
        if (nukeUpdate > 0)
        {
            nukeSprites[nukeAmount - 1].SetActive(true);
        }
        // Hides a corresponding nuke icon
        else if (nukeUpdate < 0)
        {
            nukeSprites[nukeAmount - 1].SetActive(false);
            nukeAmount--;
        }        
    }
}
