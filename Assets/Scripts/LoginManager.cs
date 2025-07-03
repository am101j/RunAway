using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

public class LoginManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject loginPanel;
    public GameObject readingPanel;

    [Header("Inputs")]
    public TMP_InputField fullNameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField readingInput;

    [Header("Texts")]
    public TextMeshProUGUI loginFeedbackText;
    public TextMeshProUGUI readingFeedbackText;
    public TextMeshProUGUI pointsText;

    User currentUser;

    public GameObject gameplayRoot;

    void Start()
    {
        gameplayRoot.SetActive(false);
    }

    public void LoginClick()
    {
        string fullName = fullNameInput.text.Trim();
        string pass = passwordInput.text.Trim();

        currentUser = DatabaseManager.db.Table<User>()
           .FirstOrDefault(u => u.FullName == fullName);

        if (currentUser == null)
        {
            loginFeedbackText.text = "User not found.";
            return;
        }

        if (currentUser.PassHash != Hash(pass))
        {
            loginFeedbackText.text = "Incorrect Password!";
            return;
        }

        loginPanel.SetActive(false);
        readingPanel.SetActive(true);

        if (pointsText != null)
        {
            pointsText.text = $"Points: {currentUser.Points}";
        }
    }

    public void InputReading()
    {
        if (!int.TryParse(readingInput.text.Trim(), out int newReading))
        {
            readingFeedbackText.text = "Enter a valid number.";
            return;
        }

        int lastReading = currentUser.LastReading;
        int lastDiff = currentUser.LastDiff;

        if (newReading < lastReading)
        {
            readingFeedbackText.text = "Reading can't be lower than before. Try again.";
            return;
        }

        int newDiff = newReading - lastReading;

        bool canPlay = (lastReading == 0 || lastDiff == 0 || newDiff <= lastDiff);

        currentUser.LastReading = newReading;
        currentUser.LastDiff = newDiff;
        DatabaseManager.db.Update(currentUser);

        if (!canPlay)
        {
            readingFeedbackText.text = "Usage has risen. Try again.";
            return;
        }

        readingPanel.SetActive(false);
        StartGame();
    }


    public void OnGuestClick()
    {
        loginPanel.SetActive(false);
        readingPanel.SetActive(false);
        StartGame();
    }

    void StartGame()
    {
        gameplayRoot.SetActive(true);
    }

    string Hash(string input)
    {
        using var sha = SHA256.Create();
        return System.BitConverter.ToString(
            sha.ComputeHash(Encoding.UTF8.GetBytes(input))
        ).Replace("-", "").ToLower();
    }
    
    public User GetCurrentUser()
    {
        return currentUser;
    }

}





