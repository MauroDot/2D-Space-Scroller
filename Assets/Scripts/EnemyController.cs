using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float _moveSpeed;

    public Vector2 _startDirection;

    public bool _shouldChangeDirection;
    public float _changeDirectionXPoint;
    public Vector2 _changedDirection;

    public GameObject _shotToFire;
    public Transform _firePoint;
    public float _timeBetweenShots;
    private float _shotCounter;

    public bool _canShoot;
    private bool _allowShooting;

    public int _currentHealth;
    public GameObject _deathEffect;

    public int _scoreValue = 100;

    public GameObject[] _powerUps;
    public int _powerupDropRate = 50;
    void Start()
    {
        _shotCounter = _timeBetweenShots;
    }
    void Update()
    {
        //transform.position -= new Vector3(_moveSpeed * Time.deltaTime, 0f, 0f);

        if(!_shouldChangeDirection)
        {
            transform.position += new Vector3(_startDirection.x * _moveSpeed * Time.deltaTime, _startDirection.y * _moveSpeed * Time.deltaTime, 0f);
        }
        else
        {
            if(transform.position.x > _changeDirectionXPoint)
            {
                transform.position += new Vector3(_startDirection.x * _moveSpeed * Time.deltaTime, _startDirection.y * _moveSpeed * Time.deltaTime, 0f);
            }
            else
            {
                transform.position += new Vector3(_changedDirection.x * _moveSpeed * Time.deltaTime, _changedDirection.y * _moveSpeed * Time.deltaTime, 0f);
            }
        }

        if(_allowShooting)
        {
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                _shotCounter = _timeBetweenShots;
                Instantiate(_shotToFire, _firePoint.position, _firePoint.rotation);
            }
        }       
    }

    public void DamageEnemy()
    {
        _currentHealth--;
        if(_currentHealth <= 0)
        {
            GameManager.instance.AddScore(_scoreValue);

            int randomCahnce = Random.Range(0, 100);
            if(randomCahnce < _powerupDropRate)
            {
                int randomPick = Random.Range(0, _powerUps.Length);
                Instantiate(_powerUps[randomPick], transform.position, transform.rotation);
            }
            
            Destroy(gameObject);
            Instantiate(_deathEffect, transform.position, transform.rotation);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnBecameVisible()
    {
        if(_canShoot)
        {
            _allowShooting = true;
        }
    }
}
