using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject deathMenu;
    public FlyingObjectManager flyingObject;
    public Transform flyingObjectSpawnPoint;
    public GameObject boxRestartPos;

    private float boxHeight;
    private float boxDistance;

    public int score;
    public int hiscore;

    public float colorChangeCoefficient;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;

    private CameraController cameraCont;
    //private ScoreManager scoreManager;

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            hiscore = PlayerPrefs.GetInt("Highscore");
            hiscoreText.text = "High Score: " + hiscore;
        } else
        {
            hiscore = 0;
            hiscoreText.text = "High Score: " + hiscore;
        }

        score = 0;
        scoreText.text = "Score: " + score;
        //scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        /*if (score > 10)
        {
            flyingObject.speed = 0f;
        }*/
        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetInt("Highscore", score);
        }

        scoreText.text = "Score: " + score;
        hiscoreText.text = "High Score: " + hiscore;

    }

    public void DeathMenuShow()
    {
        deathMenu.SetActive(true);
    }

    public void PlayerDied()
    {
        cameraCont.PlayerDied();
    }

    public void AddScore()
    {
        score += 1;
        
    }

    public void BoxRestartPosChange()
    {
        boxDistance = Random.Range(0, 5);
        boxRestartPos.transform.position = new Vector2(15 + boxDistance, 0);
    }

    public float GetBoxHeight()
    {
        boxHeight = Random.Range(-8f, -4f);
        return boxHeight;
    }

    public float GetBoxDistance()
    {
        boxDistance = Random.Range(6, 9);
        return boxDistance;
    }
}
