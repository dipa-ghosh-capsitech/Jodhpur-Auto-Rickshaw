
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    private int currentScore = 0;
    private int highScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUi();
    }


    public void AddScore(int points)
    {
        currentScore += points;
        UpdateUi();

    }
    public void ShowGameOverScores()
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = currentScore.ToString();
        }
        if (highScoreText != null)
        {
            if (currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
            }
            highScoreText.text = highScore.ToString();
        }
    }
    void UpdateUi()
    {
        scoreText.text = "Score: " + currentScore;
    }
    public void ResetScore()
    {
        currentScore = 0;
        UpdateUi();
    }
    
}
