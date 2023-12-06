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

    public Text _scoreText, hiScoreText;
    private void Awake()
    {
        instance = this;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitToMain()
    {

    }
}
