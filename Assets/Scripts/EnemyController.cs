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

    void Start()
    {
        
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
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
