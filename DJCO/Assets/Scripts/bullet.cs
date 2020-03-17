using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    public int power;
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Debug.Log(power);
    }

    //TODO: Add enemy health removal

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
            return;

        if (collision.gameObject.layer != 9 && collision.gameObject.layer != 10)
        {
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void setPower(int power)
    {
        this.power = power;
    }

}
