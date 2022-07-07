using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleManager : MonoBehaviour
{

    private Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

    public GameObject particleEffect;

    private GameManager gameManager;

    private PlayerController player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>();
    }

    
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(particleEffect, transform.position, transform.rotation);
            gameManager.DeathMenuShow();
            player.died = true;
            player.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
         else
        {
            Instantiate(particleEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
