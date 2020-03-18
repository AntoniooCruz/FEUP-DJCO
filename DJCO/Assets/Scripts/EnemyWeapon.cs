﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    [System.Serializable]
    public class WeaponStats
    {
        public float fireRate = 0.1f;
        public int bulletsPerShot = 1;
        public float BulletRate = 1.0f;
        public float Damage = 10;
    }

    public WeaponStats stats = new WeaponStats();

    float timeToFire = 0;
    Transform shotSpawn;

    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

    private void Awake()
    {
        shotSpawn = transform.Find("ShotSpawn");
        if (shotSpawn == null)
        {
            Debug.LogError("No shot spawn found");
        }
    }

    private void Update()
    {
        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / stats.fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        objectPooler.SpawnFromPool("EnemyBullet", shotSpawn.position, Quaternion.identity);
    }
}