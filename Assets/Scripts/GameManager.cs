using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int _currentLives = 5;

    public float _respawnTime = 1f;

    public int _currentScore;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UIManager.instance._livesText.text = "x " + _currentLives;

        UIManager.instance._scoreText.text = "Score: " + _currentScore;
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
    }
}
