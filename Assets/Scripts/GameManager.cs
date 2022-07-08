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

    public int score;
    public int hiscore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            hiscore = PlayerPrefs.GetInt("Highscore");
            hiscoreText.text = "High Score: " + hiscore;
        }
        else
        {
            hiscore = 0;
            hiscoreText.text = "High Score: " + hiscore;
        }

        score = 0;
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
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

    public void AddScore()
    {
        score += 1;
        
    }

    public float GetBoxHeight()
    {
        boxHeight = Random.Range(-8f, -4f);
        return boxHeight;
    }
}
