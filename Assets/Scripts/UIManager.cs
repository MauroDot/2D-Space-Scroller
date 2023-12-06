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

    public Slider _healthBar;

    public Text _scoreText;
    void Start()
    {
        instance = this;
    }
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitToMain()
    {

    }
}
