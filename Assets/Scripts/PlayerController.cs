using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float _moveSpeed;
    public Rigidbody2D _theRB;

    public Transform bottomLeftLimit, topRightLimit;

    public Transform _shotPoint;
    public GameObject _shot;

    public float _timeBetweenShots = 0.2f;
    private float _shotCounter;

    private float _normalSpeed;
    public float _boostSpeed;
    public float _boostTime;
    private float _boostCounter;

    private float boostDuration = 5f; // Adjust this value as needed
    private float boostTimer = 0f;
    private bool isBoosting = false;

    public bool _DoubleShotActive;
    public float doubleShotOffset;

    public bool _stopMovement;

    private Vector2 _currentVelocity = Vector2.zero; // Store current velocity
    private Vector2 _targetVelocity = Vector2.zero; // Target velocity

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        _normalSpeed = _moveSpeed;
    }
    void Update()
    {
        if (!_stopMovement)
        {
            // Handle boost timer
            if (isBoosting)
            {
                boostTimer -= Time.deltaTime;
                if (boostTimer <= 0f)
                {
                    // Boost duration has ended; reset speed
                    _moveSpeed = _normalSpeed;
                    isBoosting = false;
                }
            }

            // Smoothly interpolate the input velocity
            _targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _moveSpeed;
            _currentVelocity = Vector2.Lerp(_currentVelocity, _targetVelocity, Time.deltaTime * 5f);

            _theRB.velocity = _currentVelocity; // Set the rigidbody velocity

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y), transform.position.z);

            if (Input.GetButtonDown("Fire1"))
            {
                if (!_DoubleShotActive)
                {
                    Instantiate(_shot, _shotPoint.position, _shotPoint.rotation);
                }
                else
                {
                    Instantiate(_shot, _shotPoint.position + new Vector3(0f, doubleShotOffset, 0f), _shotPoint.rotation);
                    Instantiate(_shot, _shotPoint.position - new Vector3(0f, doubleShotOffset, 0f), _shotPoint.rotation);
                }

                _shotCounter = _timeBetweenShots;
            }

            if (Input.GetButton("Fire1"))
            {
                _shotCounter -= Time.deltaTime;
                if (_shotCounter <= 0)
                {
                    if (!_DoubleShotActive)
                    {
                        Instantiate(_shot, _shotPoint.position, _shotPoint.rotation);
                    }
                    else
                    {
                        Instantiate(_shot, _shotPoint.position + new Vector3(0f, doubleShotOffset, 0f), _shotPoint.rotation);
                        Instantiate(_shot, _shotPoint.position - new Vector3(0f, doubleShotOffset, 0f), _shotPoint.rotation);
                    }
                    _shotCounter = _timeBetweenShots;
                }
            }

            if (_boostCounter > 0)
            {
                _boostCounter -= Time.deltaTime;
                if (_boostCounter <= 0)
                {
                    // Smoothly decelerate to normal speed
                    _moveSpeed = Mathf.Lerp(_moveSpeed, _normalSpeed, Time.deltaTime * 5f);
                }

                if (Input.GetKeyDown(KeyCode.Space) && !_DoubleShotActive)
                {
                    if (CanActivateBoost()) // Add this check
                    {
                        ActivateSpeedBoost();
                    }
                }
            }
        }
    }
    private bool CanActivateBoost()
    {
        // Check if the player can activate the boost (e.g., has a boost power-up)
        // Add your conditions here (e.g., check if boost power-up is available)
        // Return true if the boost can be activated, otherwise return false

        return true; // Modify this based on your game's logic
    }
    public void ApplyExternalForce(Vector2 force)
    {
        _theRB.AddForce(force);
    }
    public void ActivateSpeedBoost()
    {
        _boostCounter = _boostTime;
        _moveSpeed = _boostSpeed;
        isBoosting = true;
        boostTimer = boostDuration;
    }
}
