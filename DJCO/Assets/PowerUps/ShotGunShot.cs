using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunShot : PowerUp
{

    public override void powerUp(Weapon weapon, Player player)
    {
        weapon.AddPowerUp(Weapon.powerUps.ShotgunShot);
    }
}

