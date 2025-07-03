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
    public TextMeshProUGUI factText;
    public GameObject FactPanel;
    public LoginManager loginManager;  // 🔹 Drag into Inspector


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

        if (factText != null)
        {
            FactPanel.SetActive(true);
            FunFacts facts = FindObjectOfType<FunFacts>();
            factText.text = $"Fun Fact:\n{facts.GetRandomFact()}";
        }

        // Show Game Over UI text
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);

        }

        isGameOver = true;

        if (loginManager != null)
        {
            User user = loginManager.GetCurrentUser(); // 🔹 Add this getter to LoginManager
            if (user != null)
            {
                user.Points += currentScore; // or just: user.Points = currentScore;
                DatabaseManager.db.Update(user);
            }
        }


        // Stop game time
        //Time.timeScale = 0f;
    }
}
