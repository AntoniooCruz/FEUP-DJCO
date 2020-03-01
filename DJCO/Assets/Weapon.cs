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

    public HashSet<powerUps> powerUp = new HashSet<powerUps>();

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
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void AddPowerUp(powerUps power)
    {
        powerUp.Add(power);
    }

    public void RapidFire()
    {
        fireRate = fireRate / 2;
    }
}
