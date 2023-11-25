using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
public TextMeshProUGUI scoreText;
    private int score;

    void Start()
    {
        score = 0;
        
        // UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd){
        Debug.Log(scoreToAdd);
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        // PlayerPrefs.SetString("score1", score.ToString());

    }
}