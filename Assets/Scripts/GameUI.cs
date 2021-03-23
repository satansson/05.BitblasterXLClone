using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI enemiesText;
    public TextMeshProUGUI scoreText;
    [SerializeField] Color green, red;

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

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void ChangeAmmoTextColor(bool isEmpty)
    {
        ammoText.color = isEmpty ? red : green;
    }
}
