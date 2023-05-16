using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);
    }
}