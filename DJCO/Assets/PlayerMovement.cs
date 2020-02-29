using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

 
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        var pos = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        pos.x = Mathf.Clamp(pos.x, -9f, 4f);
        pos.y = Mathf.Clamp(pos.y, -4f, 4f);

        rb.MovePosition(pos);
    }
    
}
