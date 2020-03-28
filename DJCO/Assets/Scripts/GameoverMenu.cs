using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameoverMenu : MonoBehaviour
{
    public GameObject GameoverUI;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI score;
    public AudioSource gameoverSound;

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void setFinalTime(string time) {
        this.timer.text = "YOUR TIME: " + time;
    }

    public void setFinalScore(int score) {
        this.score.text = "YOUR SCORE: " + score.ToString();
    }



}
