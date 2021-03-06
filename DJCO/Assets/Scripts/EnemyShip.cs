﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStats
    {
        public float Health = 1f;
    }

    public EnemyStats stats = new EnemyStats();

    public float speed;
    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;
    public GameObject explosion;

    private float currentSpeed;

    private float targetManeuver;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0.0f);
        stats.Health *= 1 + (0.2f*WaveSpawner.instance.waveLoopingStage);
        StartCoroutine(Evade());
    }

    // **** Movement **** // 

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.y);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {

        float newManeuver = Mathf.MoveTowards(rb.velocity.y, targetManeuver, Time.deltaTime * smoothing);

        currentSpeed = rb.velocity.x;
        rb.velocity = new Vector3(currentSpeed, newManeuver, 0.0f);
        rb.position = new Vector3
        (
            rb.position.x,
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

    }


    // **** Collisions **** // 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            other.GetComponentInParent<Player>().TakeDamage(50 + 50 * 0.1f * WaveSpawner.instance.waveLoopingStage);
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            GameController.GetInstance().KillEnemy(this);
        }

    }

    // **** Health **** // 

    public void DamageEnemy(float damage)
    {
        stats.Health -= damage;
        Debug.Log("This ship just took " + damage + " damage!!");
        if (stats.Health <= 0)
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            GameController.GetInstance().KillEnemy(this);
        }
    }

}
