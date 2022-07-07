using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower;
    public float speed;

    private float jumpCounter;

    private Rigidbody2D rb;

    private bool grounded;
    public LayerMask groundLayer;

    private Collider2D collider2d;

    private GameManager gameManager;

    private Animator animator;

    public bool died;

    private CameraController cmr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        cmr = FindObjectOfType<CameraController>();

        jumpCounter = 0;

        died = false;
    }

    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(collider2d, groundLayer);

        rb.velocity = new Vector2(speed, rb.velocity.y);

        // Change this part later for mobile capability.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Checking if the Player is touching the ground.
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x + 1f, jumpPower);
                jumpCounter = 0.5f;
            } else
            {
                jumpCounter = 0f;
            }
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            speed -= 4f;
        }

        if(Input.GetKeyUp(KeyCode.D))
        {
            speed += 4f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x + 1f, jumpPower);
                jumpCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpCounter = 0;
        }

        if (grounded)
        {
            jumpCounter = 0.5f;
        }

        animator.SetBool("Grounded", grounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathDetector"))
        {
            gameManager.DeathMenuShow();
            died = true;
            cmr.PlayerDied();
            gameObject.SetActive(false);
        }
    }
}
