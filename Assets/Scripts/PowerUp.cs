using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool _isShield;
    public bool _isBoost;
    public bool _isDoubleShot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);

            if (_isShield)
            {
                HealthManager.instance.AcitvateShield();
            }

            if (_isBoost)
            {
                PlayerController.instance.ActivateSpeedBoost();
            }

            if (_isDoubleShot)
            {
                PlayerController.instance._DoubleShotActive = true;
            }
        }
    }
}
