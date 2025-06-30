using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int maxScore = 10;                     // Max score or max obstacles count
    private int currentScore = 0;     
    public static bool isGameOver = false;
    private int obstaclesPassed = 0;           
    public TextMeshProUGUI scoreText;             // Assign your score UI text here
    public GameObject gameOverText;                // Assign your Game Over UI text here (disabled by default)

    void Start()
    {
        // Initialize score display
        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore} / {maxScore}";
        }

        // Hide Game Over text at start
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
    }

    public void ObstacleExited()
    {
        obstaclesPassed++;

        if (obstaclesPassed >= 10)
        {
            GameOver();
        }
    }

    // Call this when player passes an obstacle
    public void IncreaseScore()
    {
        if (currentScore < maxScore)
        {
            currentScore++;
            Debug.Log("Score: " + currentScore);

            if (scoreText != null)
            {
                scoreText.text = $"Score: {currentScore} / {maxScore}";
            }
        }
    }

    // Call this to end the game
    public void GameOver()
    {
        Debug.Log("Game Over!");

        // Show final score
        if (scoreText != null)
        {
            scoreText.text = $"Final Score: {currentScore} / {maxScore}";
        }

        // Show Game Over UI text
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);

        }

        isGameOver = true;

        // Stop game time
        //Time.timeScale = 0f;
    }
}
