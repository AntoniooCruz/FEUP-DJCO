using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    private void Awake() {
        instance = this;
    }
    
    public void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        FindObjectOfType<GameoverMenu>().GameoverUI.SetActive(true);
    }

    public void KillEnemy(EnemyShip enemy)
    {
        Destroy(enemy.gameObject);
    }

}
