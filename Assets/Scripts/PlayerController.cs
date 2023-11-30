using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _moveSpeed;
    public Rigidbody2D _theRB;

    public Transform bottomLeftLimit, topRightLimit;

    public Transform _shotPoint;
    public GameObject _shot;

    public float _timeBetweenShots = 0.2f;
    private float _shotCounter;
    void Start()
    {

    }

    void Update()
    {
        _theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _moveSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y), transform.position.z);

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(_shot, _shotPoint.position, _shotPoint.rotation);

            _shotCounter = _timeBetweenShots;
        }

        if (Input.GetButton("Fire1"))
        {
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                Instantiate(_shot, _shotPoint.position, _shotPoint.rotation);
                _shotCounter = _timeBetweenShots;
            }          
        }
    }
    public void ApplyExternalForce(Vector2 force)
    {
        _theRB.AddForce(force);
    }
}
