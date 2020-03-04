using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    public Sprite[] bulletsSprites = new Sprite[7];

    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    //TODO: Add enemy health removal

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer != 9 && collision.gameObject.layer != 10)
        {
            Destroy(gameObject);
        }
        
    }

    public void setPowerSprite(int powerLvl)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = bulletsSprites[powerLvl - 1];
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
