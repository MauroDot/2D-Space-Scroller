using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string _firstLevel;
    void Start()
    {

    }
    void Update()
    {
        
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("CurrentLives", 3);
        PlayerPrefs.SetInt("CurrentScore", 0);
        SceneManager.LoadScene(_firstLevel);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ClearScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("CurrentScore");
        // You can add any other PlayerPrefs keys you want to clear here
    }
}
