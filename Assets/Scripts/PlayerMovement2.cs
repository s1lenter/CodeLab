using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private InputField groundChecker;

    [SerializeField] private Text text;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private GameObject finish;

    private bool canCheckGround;

    private bool changeText = false;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    private float jumpForce = 15;
    private string[] rightAnswer = new string[]
    {
        "private bool IsGrounded()",
        "{",
        "bool result;",
        "result = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);",
        "return result",
        "}",
    };

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();   
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        finish.GetComponent<BoxCollider2D>().enabled = false;
        finish.GetComponent<Renderer>().enabled = false;
    }

    public void Update()
    {
        if (!changeText)
        {
            string[] lines = groundChecker.text.Split("\n");

            if (lines.Length == 6)
            {
                for (int i = 0; i < rightAnswer.Length; i++)
                {
                    if (lines[i] == rightAnswer[i])
                        canCheckGround = true;
                    else
                        canCheckGround = false;
                }
            }
            else
                canCheckGround = false;

            if (canCheckGround)
                Debug.Log("OK");

            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (canCheckGround)
            {
                finish.GetComponent<BoxCollider2D>().enabled = true;
                finish.GetComponent<Renderer>().enabled = true;
                if (Input.GetButtonDown("Jump") && IsGrounded())
                {
                    if (jumpForce != 0)
                        jumpSoundEffect.Play();
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }

            }

            else
            {
                if (Input.GetButtonDown("Jump"))
                {
                    if (jumpForce != 0)
                        jumpSoundEffect.Play();
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
            }


            UpdateAnimationState();
        }
        else
            StopAnimation();
    }

    public void Stop()
    {
        changeText = true;
        dirX = 0;
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (SceneManager.sceneCountInBuildSettings == 3 && canCheckGround)
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                jumpSoundEffect.Stop();
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }
    }

    public void CanMove()
    {
        changeText = false;
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
