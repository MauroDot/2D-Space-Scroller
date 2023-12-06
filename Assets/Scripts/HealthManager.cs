using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int _currentHealth;
    public int _maxHealth;
    public GameObject _deathEffect;
    public float _invincibilityTime = 2f;
    private float _invincCounter;
    public SpriteRenderer _theSR;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _currentHealth = _maxHealth;

        UIManager.instance._healthBar.maxValue = _maxHealth;
        UIManager.instance._healthBar.value = _currentHealth;
    }

    void Update()
    {
        if(_invincCounter >= 0)
        {
            _invincCounter -= Time.deltaTime;

            if(_invincCounter <= 0)
            {
                _theSR.color = new Color(_theSR.color.r, _theSR.color.g, _theSR.color.b, 1f);
            }
        }
    }

    public void DamagePlayer()
    {
        if(_invincCounter <= 0)
        {
            _currentHealth--;
            UIManager.instance._healthBar.value = _currentHealth;

            if (_currentHealth <= 0)
            {
                Instantiate(_deathEffect, transform.position, transform.rotation);
                gameObject.SetActive(false);

                GameManager.instance.KillPlayer();
                WaveManager.instance._canSpawnWaves = false;
            }
        }       
    }
    public void Respawn()
    {
        gameObject.SetActive(true);
        _currentHealth = _maxHealth;
        UIManager.instance._healthBar.value = _currentHealth;

        _invincCounter = _invincibilityTime;
        _theSR.color = new Color(_theSR.color.r, _theSR.color.g, _theSR.color.b, .5f);
    }
}
