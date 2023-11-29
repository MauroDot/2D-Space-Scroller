using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float _shotSpeed = 7f;
    public GameObject _impactEffect;
    void Start()
    {

    }
    void Update()
    {
        transform.position -= new Vector3(_shotSpeed * Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(_impactEffect, transform.position, transform.rotation);

        if(other.tag == "Player")
        {
            HealthManager.instance.DamagePlayer();
        }

        Destroy(this.gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
