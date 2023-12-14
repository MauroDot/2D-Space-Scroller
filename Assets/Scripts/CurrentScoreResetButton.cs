using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreResetButton : MonoBehaviour
{
    public Button resetButton;

    private void Start()
    {
        // Attach the function to the button's click event
        resetButton.onClick.AddListener(ResetCurrentScore);
    }

    private void ResetCurrentScore()
    {
        // Remove the current score key from PlayerPrefs
        PlayerPrefs.DeleteKey("CurrentScore");

        // Optionally, update the current score text in your UI to show that it has been reset
        GameManager.instance.currentScore = 0;
        UIManager.instance._scoreText.text = "Score: 0";

        // Hide the high score notice if it's visible (optional)
        UIManager.instance.highScoreNotice.SetActive(false);
    }
}
