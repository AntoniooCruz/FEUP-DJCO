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
        if(weapon != null)
        {
            weapon.AddPowerUp(Weapon.powerUps.RapidFire);
            powerUp(weapon);
            Destroy(gameObject);
        }
        
    }

    public abstract void powerUp(Weapon weapon);
}
