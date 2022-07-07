using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float hiscore;
    public float score;

    private GameManager gameManager;
    private PlayerController player;

    void Start()
    {
        if(PlayerPrefs.HasKey("Hiscore"))
        {
            hiscore = PlayerPrefs.GetFloat("Hiscore");
        } else
        {
            hiscore = 0;
        }

        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        
        score = gameManager.score;
        if (score > hiscore)
        {
            PlayerPrefs.SetFloat("Hiscore", score);
        }
        
    }

    public float GetHiScore()
    {
        return hiscore;
    }
}
