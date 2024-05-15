using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float speedX = 0f;
    private float speedY = 0f;
    private float moveSpeed = 30f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speedX * moveSpeed, rb.velocity.y);
        speedY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, speedY * moveSpeed);
        if (speedY == 0)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
