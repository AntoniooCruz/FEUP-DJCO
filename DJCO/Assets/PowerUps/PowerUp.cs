using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    public float speed = 5f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Weapon weapon = collision.GetComponent<Weapon>();
        Player player = collision.GetComponent<Player>();
        if (weapon != null)
        {
            powerUp(weapon,player);
            Destroy(gameObject);
        }
        
    }

    public abstract void powerUp(Weapon weapon, Player player);
}
