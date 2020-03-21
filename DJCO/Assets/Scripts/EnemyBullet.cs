using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public GameObject explosion;
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
            Debug.Log("ENEMY VS PLAYER");
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(this.gameObject);
        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            other.GetComponentInParent<Player>().TakeDamage(10);
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
