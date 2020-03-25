using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emerald : PowerUp
{ 
    public override void powerUp(Weapon weapon, Player player)
    {
        weapon.IncreasePower();
    }
}
