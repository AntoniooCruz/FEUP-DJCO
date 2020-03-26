using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour, IPooledObject
{
    public float speed;
    public GameObject explosion;
    private Rigidbody2D rb;
    private Transform player;

    public void OnObjectSpawn()
    {
        player = GameObject.FindObjectOfType<Player>().transform;

        rb = GetComponent<Rigidbody2D>();

        Vector2 difference = player.position - transform.position;
        difference.Normalize();
        rb.velocity = difference * new Vector2(speed, speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (LayerMask.LayerToName(other.gameObject.layer) == "PlayerBullet")
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            this.gameObject.SetActive(false);

        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            other.GetComponentInParent<Player>().TakeDamage(10 + 10 * 0.1f * WaveSpawner.instance.waveLoopingStage);
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            this.gameObject.SetActive(false);

        }
    }

}
