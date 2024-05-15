using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private InputField inputSpeed;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private float moveSpeed;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();   
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (inputSpeed == null)
            moveSpeed = 0;
        else if (int.TryParse(inputSpeed.text, out int result))
            if (result > 40)
                moveSpeed = 40;
        else
            float.TryParse(inputSpeed.text, out moveSpeed);

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); 

        //if (Input.GetButtonDown("Jump") && IsGrounded())
        //{
        //    jumpSoundEffect.Play();
        //    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //}

        UpdateAnimationState();
    }

    public void Stop()
    {
        dirX = 0;
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Stop();
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }

        
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

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
