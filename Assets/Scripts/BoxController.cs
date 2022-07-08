using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private GameObject restartPosition;

    private GameManager gameManager;

    private float randomHeight;

    public GameObject triggerObj;

    void Start()
    {
        restartPosition = GameObject.Find("Box Restart Position");
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimitBarrier"))
        {
            randomHeight = gameManager.GetBoxHeight();
            transform.position = new Vector2(restartPosition.transform.position.x, randomHeight);
            triggerObj.SetActive(true);
        }
    }
}
