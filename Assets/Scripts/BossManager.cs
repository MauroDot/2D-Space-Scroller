using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instnace;
    public string _bossName;

    public int _currentHealth = 100;

    public BattleShot[] _shotToFire;
    public void Awake()
    {
        instnace = this;
    }
    void Start()
    {
        UIManager.instance._bossName.text = _bossName;
        UIManager.instance._bossHealthSlider.maxValue = _currentHealth;
        UIManager.instance._bossHealthSlider.value = _currentHealth;
        UIManager.instance._bossHealthSlider.gameObject.SetActive(true);

        MusicController.instance.PlayBoss();
    }
    void Update()
    {
        for(int i = 0; i < _shotToFire.Length; i++ )
        {
            _shotToFire[i]._shotCounter -= Time.deltaTime;

            if(_shotToFire[i]._shotCounter <= 0)
            {
                _shotToFire[i]._shotCounter = _shotToFire[i]._timeBetweenShots;
                Instantiate(_shotToFire[i]._theShot, _shotToFire[i]._firePoint.position, _shotToFire[i]._firePoint.rotation);
            }
        }
    }
    public void HurBoss()
    {
        _currentHealth--;
        UIManager.instance._bossHealthSlider.value = _currentHealth;

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            UIManager.instance._bossHealthSlider.gameObject.SetActive(false);
        }
    }
}

[System.Serializable]
public class BattleShot
{
    public GameObject _theShot;
    public float _timeBetweenShots;
    public float _shotCounter;
    public Transform _firePoint;
}
