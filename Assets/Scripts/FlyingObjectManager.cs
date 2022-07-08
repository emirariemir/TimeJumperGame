using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObjectManager : MonoBehaviour
{
    private Rigidbody2D rb;

    private GameManager gameManager;

    public GameObject missle;

    private float timer;

    private PlayerController player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>();

        timer = 0f;
    }

    void Update()
    {
        if (gameManager.score > 10)
        {
            rb.velocity = new Vector2(3f, 0);
            if (timer < Time.time && player.died == false)
            {
                timer = Time.time + 2f;
                Instantiate(missle, transform.position, transform.rotation); // Thats the place where we launch missle!
            }
        }
        else
        {
            rb.velocity = new Vector2(6f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimitBarrier"))
        {
            transform.position = new Vector2(transform.position.x + 30, transform.position.y);
        }
    }
}
