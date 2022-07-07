using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float speed;

    //private float lastHeight;

    private Rigidbody2D rb;

    private GameObject restartPosition;

    private GameManager gameManager;

    private float randomHeight;
    private float randomDistance;

    public GameObject boxRestartPos;

    public GameObject triggerObj;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        restartPosition = GameObject.Find("Box Restart Position");

        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Entered");

        if (collision.gameObject.tag == "LimitBarrier")
        {
            randomHeight = gameManager.GetBoxHeight();
            transform.position = new Vector2(restartPosition.transform.position.x, randomHeight);
            //restartPosition.transform.position = new Vector2(restartPosition.transform.position.x + randomDistance, restartPosition.transform.position.y);
            //gameManager.BoxRestartPosChange();
            triggerObj.SetActive(true);
        }
    }
}
