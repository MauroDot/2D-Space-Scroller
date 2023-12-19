using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int _currentLives = 3;
    public float _respawnTime = 1f;
    public int currentScore;

    private int highScore;

    public bool _levelEnding;

    private int levelScore;

    public float _waitForLevelEnd = 5f;

    public string _nextLevel;

    private bool _canPause;

    private bool _gameOver;
    private float _countdownTimer = 5f; // Adjust the countdown duration as needed
    public string _mainMenuName = "Menu";
    private void Awake()
    {
        instance = this;
        // Load high score at the beginning
        //highScore = PlayerPrefs.GetInt("HighScore", 0); // Default to 0 if not set
    }

    void Start()
    {
        _currentLives = PlayerPrefs.GetInt("CurrentLives", 3); // Default to 3 lives if not set
        UIManager.instance._livesText.text = "x " + _currentLives;

        highScore = PlayerPrefs.GetInt("HighScore", 0); // Initialize highScore from PlayerPrefs, defaulting to 0
        currentScore = PlayerPrefs.GetInt("CurrentScore", 0); // Load the current score

        UIManager.instance._hiScoreText.text = "Hi-Score: " + highScore;
        UIManager.instance._scoreText.text = "Score: " + currentScore;

        _canPause = true;
    }

    void Update()
    {
        if(_levelEnding)
        {
            PlayerController.instance.transform.position += new Vector3(PlayerController.instance._boostSpeed * Time.deltaTime, 0f, 0f);
        }
        
        if (_gameOver)
        {
            _countdownTimer -= Time.deltaTime;
            if (_countdownTimer <= 0f)
            {
                ReturnToMainMenu();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && _canPause)
        {
            PauseUnpause();
        }
    }
    public void KillPlayer()
    {
        _currentLives--;
        UIManager.instance._livesText.text = "x " + _currentLives;

        if (_currentLives > 0)
        {
            StartCoroutine(RespawnCO());
        }
        else
        {
            UIManager.instance._gameOverScreen.SetActive(true);
            WaveManager.instance._canSpawnWaves = false;
            MusicController.instance.PlayGameOver();

            PlayerPrefs.SetInt("HighScore", highScore);

            _canPause = false;

            _gameOver = true; // Set the game over flag
        }
    }
    public IEnumerator RespawnCO()
    {
        yield return new WaitForSeconds(_respawnTime);
        HealthManager.instance.Respawn();
        WaveManager.instance.ContinueSpawning();
    }
    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        levelScore += scoreToAdd;
        UIManager.instance._scoreText.text = "Score: " + currentScore;

        // Load the stored high score from PlayerPrefs
        int storedHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentScore > storedHighScore)
        {
            // Update the stored high score with the current score
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScore = currentScore;
            UIManager.instance._hiScoreText.text = "Hi-Score: " + highScore;

            // Enable the notice only if the current score surpasses the stored high score
            UIManager.instance.highScoreNotice.SetActive(true);
        }
        else
        {
            // Disable the notice if the current score is not higher than the stored high score
            UIManager.instance.highScoreNotice.SetActive(false);
        }

        // Save the current score
        PlayerPrefs.SetInt("CurrentScore", currentScore);
    }
    public IEnumerator EndLevelCO()
    {
        UIManager.instance._levelEndScreen.SetActive(true);
        PlayerController.instance._stopMovement = true;
        _levelEnding = true;
        MusicController.instance.PlayVictory();

        _canPause = false;

        yield return new WaitForSeconds(.3f);

        UIManager.instance._endLevelScore.text = "Level Score: " + levelScore;
        UIManager.instance._endLevelScore.gameObject.SetActive(true);

        yield return new WaitForSeconds(.3f);
        
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        UIManager.instance._endCurrentScore.text = "Total Score: " + currentScore;
        UIManager.instance._endCurrentScore.gameObject.SetActive(true);

        if(currentScore == highScore)
        {
            yield return new WaitForSeconds(.3f);
            UIManager.instance.highScoreNotice.SetActive(true);
        }

        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("CurrentLives", _currentLives);

        yield return new WaitForSeconds(_waitForLevelEnd);

        SceneManager.LoadScene(_nextLevel);
    }
    public void PauseUnpause()
    {
        if(UIManager.instance._pauseScreen.activeInHierarchy)
        {
            UIManager.instance._pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            PlayerController.instance._stopMovement = false;
        }
        else
        {
            UIManager.instance._pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            PlayerController.instance._stopMovement = true;
        }
    }
    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene(_mainMenuName);
    }
}
