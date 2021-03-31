using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;

    public int highscoreInt = 0;

    private void Awake()
    {
        // Assigning to the highscore either PlayerPrefs value or 0
        highscoreInt = PlayerPrefs.HasKey("Highscore")? PlayerPrefs.GetInt("Highscore") : 0;

        highscoreText.text = "Highscore: " + highscoreInt;
    }

    public void OnPlayClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
