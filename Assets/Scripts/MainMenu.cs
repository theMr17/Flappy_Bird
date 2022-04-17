using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        UnityEngine.Debug.Log("QUIT!!");
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShowHighscore()
    {
        SceneManager.LoadScene("Highscore");
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        SceneManager.LoadScene("Highscore");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}