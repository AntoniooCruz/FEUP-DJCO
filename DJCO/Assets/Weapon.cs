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

    public Dictionary<powerUps,int> powerUp = new Dictionary<powerUps,int>();

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
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void AddPowerUp(powerUps power)
    {
        IncrementCount(powerUp, power);
    }

    public void RapidFire()
    {
        fireRate = fireRate / 2;
    }

    private void ShotGunShot()
    {
        for(int i = 1; i <= powerUp[powerUps.ShotgunShot]; i++)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 20 / i));
            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, -20 / i));
        }
        
    }

    private void IncrementCount(Dictionary<powerUps,int> powers,powerUps power)
    {
        int currentCount;
        if(powers.TryGetValue(power,out currentCount))
        {
            powers[power] = currentCount + 1;
        }
        else
        {
            powers[power] = 1;
        }
    }
}
