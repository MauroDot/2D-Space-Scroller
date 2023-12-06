using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public float _shotSpeed = 7f;
    public GameObject _impactEffect;

    public GameObject _objectExplosion;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position += new Vector3(_shotSpeed * Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(_impactEffect, transform.position, transform.rotation);

        if(other.tag == "Space Object")
        {
            Instantiate(_objectExplosion, other.transform.position, other.transform.rotation);

            Destroy(other.gameObject);

            GameManager.instance.AddScore(10);
        }

        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEnemy();
        }

        Destroy(this.gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
