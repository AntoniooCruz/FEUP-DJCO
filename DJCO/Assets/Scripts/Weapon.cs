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
    public GameObject[] bulletPrefabs = new GameObject[6];
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    private int powerLvl = 0;
    public PowerBar powerBar;
    public GameObject[] uiRapidFire = new GameObject[3];
    public GameObject[] uiShotgun = new GameObject[3];


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
        var obj = Instantiate(bulletPrefabs[powerLvl], firePoint.position, firePoint.rotation);
        
    }

    public void AddPowerUp(powerUps power)
    {
        IncrementCount(powerUp, power);
        switch (Enum.GetName(typeof(powerUps), power))
        {
            case "ShotgunShot":
                uiShotgun[powerUp[power]-1].SetActive(true);
                break;
            case "RapidFire":
                uiRapidFire[powerUp[power]-1].SetActive(true);
                break;
            default:
                break;
        }
    }

    public void RapidFire()
    {
        if(fireRate > 0.3f)
        {
            AddPowerUp(powerUps.RapidFire);
            fireRate = fireRate / 1.2f;
        }
    }

    private void ShotGunShot()
    {
        for (int i = 1; i <= powerUp[powerUps.ShotgunShot] && i <= 3; i++)
        {
            var obj1 = Instantiate(bulletPrefabs[powerLvl], firePoint.position, Quaternion.Euler(0, 0, 20 / i));
            var obj2 = Instantiate(bulletPrefabs[powerLvl], firePoint.position, Quaternion.Euler(0, 0, -20 / i));
        }

    }

    private void IncrementCount(Dictionary<powerUps, int> powers, powerUps power)
    {
        int currentCount;
        if (powers.TryGetValue(power, out currentCount))
        {
            if(currentCount < 3)
            {
                powers[power] = currentCount + 1;
            }
        }
        else
        {
            powers[power] = 1;
        }

    }

    public void IncreasePower()
    {
        if (powerLvl < 5)
        {
            powerLvl++;
        }
        powerBar.SetPowerlvl(powerLvl);
    }

    public int getPowerLvl()
    {
        return powerLvl;
    }
}
