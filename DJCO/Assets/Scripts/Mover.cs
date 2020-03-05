using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0.0f);
    }
}
