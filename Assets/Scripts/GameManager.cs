using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int _currentLives = 3;
    public float _respawnTime = 1f;
    public int _currentScore;

    private int highScore;

    public void Awake()
    {
        instance = this;

        // Load high score at the beginning
        highScore = PlayerPrefs.GetInt("HighScore", 0); // Default to 0 if not set
    }

    private void Start()
    {
        UIManager.instance._livesText.text = "x " + _currentLives;
        UIManager.instance._scoreText.text = "Score: " + _currentScore;
        UIManager.instance.hiScoreText.text = "Hi-Score: " + highScore;
    }
    public void KillPlayer()
    {
        _currentLives--;
        UIManager.instance._livesText.text = "x " + _currentLives;

        if(_currentLives > 0)
        {
            StartCoroutine(RespawnCO());
        }
        else
        {
            UIManager.instance._gameOverScreen.SetActive(true);
            WaveManager.instance._canSpawnWaves = false;

            MusicController.instance.PlayGameOver();
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
        _currentScore += scoreToAdd;
        UIManager.instance._scoreText.text = "Score: " + _currentScore;

        if (_currentScore > highScore)
        {
            highScore = _currentScore;
            UIManager.instance.hiScoreText.text = "Hi-Score: " + highScore;

            // Save the new high score
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
    public IEnumerator EndLevelCO()
    {
        UIManager.instance._levelEndScreen.SetActive(true);
        yield return new WaitForSeconds(.1f);
    }
}
