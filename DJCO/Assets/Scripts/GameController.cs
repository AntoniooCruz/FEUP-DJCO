using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private static GameController instance;
    public Timer gameTimer;

    private int score;

    private void Awake() {
        instance = this;
        score = 0;
    }
    
    public void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        // gameTimer.timerStop();
        FindObjectOfType<GameoverMenu>().GameoverUI.SetActive(true);
    }

    public void KillEnemy(EnemyShip enemy)
    {
        Destroy(enemy.gameObject);
        score += 50;
    }

    public void RestartGame() {
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
