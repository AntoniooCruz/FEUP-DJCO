using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Weapon weapon = collision.GetComponent<Weapon>();
        if(weapon != null)
        {
            weapon.AddPowerUp(Weapon.powerUps.RapidFire);
            powerUp(weapon);
            Destroy(gameObject);
        }
        
    }

    public abstract void powerUp(Weapon weapon);
}
