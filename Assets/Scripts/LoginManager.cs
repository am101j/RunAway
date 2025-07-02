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

    User currentUser;

    public GameObject gameplayRoot;

    void Start ()
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
    }

    public void InputReading()
    {
        if (!int.TryParse(readingInput.text.Trim(), out int newReading))
        {
            readingFeedbackText.text = "Enter valid number";
            return;
        }

        int newDiff = newReading - currentUser.LastReading;
        int lastDiff = currentUser.LastDiff;
        bool canPlay = lastDiff == 0 || newDiff <= lastDiff;

        currentUser.LastReading = newReading;
        currentUser.LastDiff = newDiff;
        DatabaseManager.db.Update(currentUser);

        if (canPlay)
        {
            readingPanel.SetActive(false);
            StartGame();
        }
        else
        {
            readingFeedbackText.text = "Usage has risen!";
        }
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
}





