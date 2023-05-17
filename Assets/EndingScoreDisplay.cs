using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        // Get the saved score from player preferences
        int finalScore = PlayerPrefs.GetInt("FinalScore");

        // Display the score
        scoreText.text = "Final Score: " + finalScore;
    }

    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
