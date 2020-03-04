﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }

    // Update is called once per frame
    void Fire()
    {
        Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);    
    }
}
