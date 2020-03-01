using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerUp
{

    public override void powerUp(Weapon weapon)
    {
        weapon.RapidFire();
    }
}
