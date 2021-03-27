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

    public int shieldsAmount = 5;
    public int nukesAmount = 5;
    int score = 0;

    private void Start()
    {
        green = ammoText.color;
    }

    public void UpdateAmmo(int ammo)
    {
        ammoText.text = "Ammo: " + ammo.ToString();
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
        if (change > 0 && shieldsAmount < 5)
        {
            shieldsAmount += change;
        }
        else if (change < 0 && shieldsAmount > 0)
        {
            shieldsAmount += change;
        }
    }

    public void UpdateNuke(int change)
    {
        if (change > 0 && shieldsAmount < 5)
        {
            nukesAmount++;
            nukeSprites[nukesAmount - 1].SetActive(true);
        }
        else if (change < 0 && shieldsAmount > 0)
        {
            nukeSprites[nukesAmount - 1].SetActive(false);
            nukesAmount--;
        }        
    }
}
