using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public enum powerUps
    {
        MultiShot,
        RapidFire,
        ShotgunShot,

    }

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;
    private float nextFire = 0.0f;
    private int powerLvl = 1;

    public Dictionary<powerUps, int> powerUp = new Dictionary<powerUps, int>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (powerUp.ContainsKey(powerUps.ShotgunShot))
        {
            ShotGunShot();
        }
        var obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        obj.GetComponent<bullet>().setPowerSprite(powerLvl);
    }

    public void AddPowerUp(powerUps power)
    {
        IncrementCount(powerUp, power);
    }

    public void RapidFire()
    {
        if(fireRate > 0.025f)
        {
            fireRate = fireRate / 2;
        }
    }

    private void ShotGunShot()
    {
        for (int i = 1; i <= powerUp[powerUps.ShotgunShot] && i <= 3; i++)
        {
            var obj1 = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 20 / i));
            var obj2 = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, -20 / i));
            obj1.GetComponent<bullet>().setPowerSprite(powerLvl);
            obj2.GetComponent<bullet>().setPowerSprite(powerLvl);
        }

    }

    private void IncrementCount(Dictionary<powerUps, int> powers, powerUps power)
    {
        int currentCount;
        if (powers.TryGetValue(power, out currentCount))
        {
            powers[power] = currentCount + 1;
        }
        else
        {
            powers[power] = 1;
        }
    }

    public void IncreasePower()
    {
        if (powerLvl < 7)
        {
            powerLvl++;
        }
    }

    public int getPowerLvl()
    {
        return powerLvl;
    }
}
