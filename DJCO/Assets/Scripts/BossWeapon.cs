using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public enum attackState
    {
        MultiShot,
        RapidFire
    }

    Transform player;
    ObjectPooler objectPooler;

    float timeToFire = 0;
    float rotz;
    public bool enraged;
    public Transform shotSpawn;
    public float betweenAttackTime;

    public float multiShot_fireRate;
    public float powerShot_FireRate;
    public string multiShot_bullet;
    public string powerShot_bullet;



    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.instance;
        player = GameObject.FindObjectOfType<Player>().transform;

        shotSpawn = transform.Find("ShotSpawn");
        if (shotSpawn == null)
        {
            Debug.LogError("No shot spawn found");
        }
    }



    // Update is called once per frame
    void Update()
    {

        // Arm Rotation 
        Vector2 difference = player.position - transform.position;
        difference.Normalize();

        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz - 180);

        if(enraged) {
            multiShot_fireRate += 0.2f;
            powerShot_FireRate += 0.2f;
            enraged = false;
        }

    }

    public void PowerShot()
    {
        objectPooler.SpawnFromPool(powerShot_bullet, shotSpawn.position, Quaternion.Euler(0f, 0f, rotz - 180));
    }

    public void MultiShot()
    {
        objectPooler.SpawnFromPool(multiShot_bullet, shotSpawn.position, Quaternion.Euler(0f, 0f, rotz - 180));
        objectPooler.SpawnFromPool(multiShot_bullet, shotSpawn.position, Quaternion.Euler(0f, 0f, rotz - 180 + 20));
        objectPooler.SpawnFromPool(multiShot_bullet, shotSpawn.position, Quaternion.Euler(0f, 0f, rotz - 180 - 20));
    }

    public void stopShooting()
    {
        this.GetComponent<Animator>().SetTrigger("Idle");
    }
}
