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

    public bool _DoubleShotActive;
    public float doubleShotOffset;

    public bool _stopMovement;

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
        if(!_stopMovement)
        {
            _theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _moveSpeed;

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
                    _moveSpeed = _normalSpeed;
                }
            }
        }
        
    }
    public void ApplyExternalForce(Vector2 force)
    {
        _theRB.AddForce(force);
    }

    public void ActivateSpeedBoost()
    {
        _boostCounter = _boostTime;
        _moveSpeed = _boostSpeed;
    }
}
