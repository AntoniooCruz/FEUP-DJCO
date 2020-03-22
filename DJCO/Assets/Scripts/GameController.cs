using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    
    public void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
    }

    public void KillEnemy(EnemyShip enemy)
    {
        Destroy(enemy.gameObject);
    }
}
