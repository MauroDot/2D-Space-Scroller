using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreResetButton : MonoBehaviour
{
    public Button resetButton;

    private void Start()
    {
        // Attach the function to the button's click event
        resetButton.onClick.AddListener(ResetHighScore);
    }

    private void ResetHighScore()
    {
        // Remove the high score key from PlayerPrefs
        PlayerPrefs.DeleteKey("HighScore");

        // Optionally, update the high score text in your UI to show that it has been reset
        UIManager.instance._hiScoreText.text = "Hi-Score: 0"; // Assuming you initialize high score as 0

        // Hide the high score notice if it's visible (optional)
        UIManager.instance.highScoreNotice.SetActive(false);
    }
}
