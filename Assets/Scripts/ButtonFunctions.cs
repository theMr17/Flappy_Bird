using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public Text yourScore;
    public Text highScore;

    void Start()
    {
        if (Bird.gameover)
        {
            yourScore.text = Bird.score.ToString();
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
            Bird.gameover = false;
        }

        if(BackgroundMusicPlayer.showHighScore)
        {
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        BackgroundMusicPlayer.showHighScore = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void HighScore()
    {
        BackgroundMusicPlayer.showHighScore = true;
        SceneManager.LoadScene("HighScoreMenu");
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
