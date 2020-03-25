using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : PowerUp
{
    public int healAmount;

    public override void powerUp(Weapon weapon, Player player)
    {
        player.healDamage(healAmount);
        player.PlayRingSound();
        GameController.GetInstance().AddScore(100);
    }
}
