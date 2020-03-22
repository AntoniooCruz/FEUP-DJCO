using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Boundary boundary;
    Vector2 movement;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    public float health;
    public int maxHealth = 100;

    public HealthBar healthBar;
    public GameObject explosion;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        var pos = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        pos.x = Mathf.Clamp(pos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        pos.y = Mathf.Clamp(pos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        rb.MovePosition(pos);
    }

    // **** Damage **** //

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(Mathf.FloorToInt(health));
        Debug.Log("Player just took " + damage + " damage!!");

        if (health <= 0)
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            GameController.instance.KillPlayer(this);
        }
    }

    // **** Collision **** //

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

}
