using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private static GameController instance;
    public Timer gameTimer;

    private int score;

    private void Awake()
    {
        instance = this;
        score = 0;
    }

    public void KillPlayer(Player player)
    {
        gameTimer.TimerStop();
        Destroy(player.gameObject);
        GameoverMenu menu = FindObjectOfType<GameoverMenu>();
        menu.setFinalScore(score);
        menu.setFinalTime(gameTimer.getTime());
        menu.GameoverUI.SetActive(true);
        menu.gameoverSound.Play();
    }

    public void KillEnemy(EnemyShip enemy)
    {
        Destroy(enemy.gameObject);
        EnemyScoreHandler(enemy);
    }

    private void EnemyScoreHandler(EnemyShip enemy)
    {
        if (enemy.name.Equals("EnemyBird(Clone)"))
        {
            score += 50;
        }
        else
        {
            score += 400;
        }
    }

    public void KillBoss(Boss boss)
    {
        Destroy(boss.gameObject);
        score += 1000;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public static GameController GetInstance()
    {
        return instance;
    }

    public int GetScore()
    {
        return score;
    }
}
