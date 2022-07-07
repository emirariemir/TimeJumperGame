using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController playerCont;

    public float skyLimit;

    public float speed;

    private Rigidbody2D rb;

    //private Vector3 upliftPos;

    //private float moveDistanceY;

    private Vector3 playerPosition;

    public Vector3 offset = new Vector3(0, 0, 0);

    public float smoothing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerCont = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        /*moveDistance = playerCont.transform.position.x - lastPlayerPos.x;

        transform.position = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);

        lastPlayerPos = playerCont.transform.position;*/

        rb.velocity = new Vector3(6f, 0, 0);
    }

    public void PlayerDied()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
