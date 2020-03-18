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

    [SerializeField] private LayerMask layerMask;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Boundary boundary;
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
