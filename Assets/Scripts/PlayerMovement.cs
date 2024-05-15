using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private InputField inputSpeed;

    private float dirX = 0f;
    private float moveSpeed;

    private enum MovementState { idle, running, jumping, falling }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (!float.TryParse(inputSpeed.text,out float value))
            moveSpeed = 0;
        else if (float.TryParse(inputSpeed.text, out float result))
            if (result > 40)
                moveSpeed = 40;
        else if (float.TryParse(inputSpeed.text, out float newResult))
            moveSpeed = newResult;

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); 

        UpdateAnimationState();
    }

    public void Stop()
    {
        dirX = 0;
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    public void StopAnimation()
    {
        MovementState state = MovementState.idle;
        anim.SetInteger("state", (int)state);
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
