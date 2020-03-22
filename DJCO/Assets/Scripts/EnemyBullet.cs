using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour, IPooledObject
{
    public float speed;
    public GameObject explosion;
    private Rigidbody2D rb;

    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0.0f);
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
