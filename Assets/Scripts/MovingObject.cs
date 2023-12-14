using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float _moveSpeed;
    void Update()
    {
        transform.position -= new Vector3(_moveSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}