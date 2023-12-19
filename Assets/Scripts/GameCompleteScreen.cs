using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCompleteScreen : MonoBehaviour
{
    public float _timeBetweenTexts;
    public bool _canExit;
    public string _mainMenuName = "Menu";
    public Text _message, _score, _pressKey;
    void Start()
    {
        StartCoroutine(ShowTextCo());
    }

    void Update()
    {
        if(_canExit && Input.anyKeyDown)
        {
            SceneManager.LoadScene(_mainMenuName);
        }
    }

    public IEnumerator ShowTextCo()
    {
        yield return new WaitForSeconds(_timeBetweenTexts);
        _message.gameObject.SetActive(true);
        yield return new WaitForSeconds(_timeBetweenTexts);
        _score.text = "Final Score: " + PlayerPrefs.GetInt("CurrentScore");
        _score.gameObject.SetActive(true);
        yield return new WaitForSeconds(_timeBetweenTexts);
        _pressKey.gameObject.SetActive(true);
        _canExit = true;
    }
}
