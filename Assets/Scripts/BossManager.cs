using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instnace;
    public string _bossName;

    public int _currentHealth = 100;

    //public BattleShot[] _shotToFire;

    public BattlePhase[] _phases;
    public int _currentPhase;
    public Animator _bossAnim;

    public GameObject _endExplosion;
    public bool _battleEnding;
    public float _timeToExplosionEnd;
    public float _waitToEndLevel;

    public int _scoreValue = 5000;

    public Transform _theBoss;
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
        /*for(int i = 0; i < _shotToFire.Length; i++ )
        {
            _shotToFire[i]._shotCounter -= Time.deltaTime;

            if(_shotToFire[i]._shotCounter <= 0)
            {
                _shotToFire[i]._shotCounter = _shotToFire[i]._timeBetweenShots;
                Instantiate(_shotToFire[i]._theShot, _shotToFire[i]._firePoint.position, _shotToFire[i]._firePoint.rotation);
            }
        }*/
        if(!_battleEnding)
        {
            if (_currentHealth <= _phases[_currentPhase].healthToEndPhase)
            {
                _phases[_currentPhase].removeAtPhaseEnd.SetActive(false);
                Instantiate(_phases[_currentPhase].addAtPhaseEnd, _phases[_currentPhase].newSpawnPoint.position, _phases[_currentPhase].newSpawnPoint.rotation);

                _currentPhase++;

                _bossAnim.SetInteger("Phase", _currentPhase + 1);
            }
            else
            {
                for (int i = 0; i < _phases[_currentPhase]._phaseShots.Length; i++)
                {
                    _phases[_currentPhase]._phaseShots[i]._shotCounter -= Time.deltaTime;

                    if (_phases[_currentPhase]._phaseShots[i]._shotCounter <= 0)
                    {
                        _phases[_currentPhase]._phaseShots[i]._shotCounter = _phases[_currentPhase]._phaseShots[i]._timeBetweenShots;
                        Instantiate(_phases[_currentPhase]._phaseShots[i]._theShot, _phases[_currentPhase]._phaseShots[i]._firePoint.position, _phases[_currentPhase]._phaseShots[i]._firePoint.rotation);
                    }
                }
            }
        }      
    }
    public void HurtBoss()
    {
        _currentHealth--;
        UIManager.instance._bossHealthSlider.value = _currentHealth;

        if (_currentHealth <= 0 && !_battleEnding)
        {
            /*Destroy(gameObject);
            UIManager.instance._bossHealthSlider.gameObject.SetActive(false);*/

            _battleEnding = true;
            StartCoroutine(EndBatlleCo());
        }
    }
    public IEnumerator EndBatlleCo()
    {
        UIManager.instance._bossHealthSlider.gameObject.SetActive(false);
        Instantiate(_endExplosion, _theBoss.position, _theBoss.rotation);
        _bossAnim.enabled = false;
        GameManager.instance.AddScore(_scoreValue);

        yield return new WaitForSeconds(_timeToExplosionEnd);

        _theBoss.gameObject.SetActive(false);

        yield return new WaitForSeconds(_waitToEndLevel);
        StartCoroutine(GameManager.instance.EndLevelCO());
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

[System.Serializable]
public class BattlePhase
{
    public BattleShot[] _phaseShots;
    public int healthToEndPhase;
    public GameObject removeAtPhaseEnd;
    public GameObject addAtPhaseEnd;
    public Transform newSpawnPoint;
}
