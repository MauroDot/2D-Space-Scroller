using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int _currentHealth;
    public int _maxHealth;
    public GameObject _deathEffect;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    void Update()
    {
        
    }

    public void DamagePlayer()
    {
        _currentHealth--;

        if(_currentHealth <= 0)
        {
            Instantiate(_deathEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
