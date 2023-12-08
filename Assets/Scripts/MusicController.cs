using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public AudioSource _levelMusic, _bossMusic, _victoryMusic, _gameOverMusic;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        _levelMusic.Play();
    }
    void Update()
    {
        
    }

    void StopMusic()
    {
        _levelMusic.Stop();
        _bossMusic.Stop();
        _victoryMusic.Stop();
        _gameOverMusic.Stop();
    }

    public void PlayBoss()
    {
        StopMusic();
        _bossMusic.Play();
    }

    public void PlayVictory()
    {
        StopMusic();
        _victoryMusic.Play();
    }

    public void PlayGameOver()
    {
        StopMusic();
        _gameOverMusic.Play();
    }
}
