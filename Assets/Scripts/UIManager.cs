using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject _gameOverScreen;

    public Text _livesText;

    public Slider _healthBar, _shieldBar;

    public Text _scoreText, _hiScoreText;

    public GameObject _levelEndScreen;

    public Text _endLevelScore, _endCurrentScore;
    public GameObject highScoreNotice;

    public GameObject _pauseScreen;

    public string _mainMenuName = "Menu";

    public Slider _bossHealthSlider;
    public Text _bossName;
    private void Awake()
    {
        instance = this;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void QuitToMain()
    {
        SceneManager.LoadScene(_mainMenuName);
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        GameManager.instance.PauseUnpause();
    }
}
