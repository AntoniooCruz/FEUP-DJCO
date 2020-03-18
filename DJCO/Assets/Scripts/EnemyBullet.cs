using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "PlayerBullet")
        {
            Debug.Log("EnemyBullet VS PlayerBullet");
            //TODO
            // Bullet Small Explosion
            // Destroy this bullet
            Destroy(this.gameObject);
        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            Debug.Log("EnemyBullet VS Player");
            //TODO
            // Bullet Small Explosion
            // Destroy this bullet
            Destroy(this.gameObject);
        }
    }
}
