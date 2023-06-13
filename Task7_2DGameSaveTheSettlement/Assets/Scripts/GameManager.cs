using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WatchTimerHandler _addToWheatWatchHandler;
    [SerializeField] private WatchTimerHandler _subtractFromWheatWatchHandler;
    [SerializeField] private WatchTimerHandler _enemiesWatchHandler;
    [SerializeField] private Image _timerForRecruitmentPeasant;
    [SerializeField] private Image _timerForRecruitmentWarrior;
    [SerializeField] private Button _hirePeasant;
    [SerializeField] private Button _hireWarrior;

    [SerializeField] private Text _wheatCounterText;
    [SerializeField] private Text _peasantCounterText;
    [SerializeField] private Text _warriorsCounterText;
    [SerializeField] private Text _enemiesSurgeCounterText;
    [SerializeField] private Text _counterOfEnemiesInNewSurgeText;

    private int _wheatCounter;
    private int _peasantCounter = 2;
    private int _warriorsCounter;

    private float _peasantCreateTime = 5;
    private float _currentPeasantTimer = -2;
    private float _warriorCreateTime = 5;
    private float _currentWarriorTimer = -2;

    private int _peasentPrice = 3;
    private int _warriorPrice = 5;

    private bool _isRecruitmentingOfPeasant = false;
    private bool _isRecruitmentingOfWarrior = false;

    private int _increasingToEnemies = 2;
    private int _counterOfSurges = 1;
    private int _counterOfEnemies = 0;
    private float _addTimeToNewSurge;

    void Start()
    {
        _peasantCounterText.text = _peasantCounter.ToString();
        _addTimeToNewSurge = _enemiesWatchHandler._maxTime * 0.6f;
    }

    void Update()
    {
        if(_addToWheatWatchHandler.isTick)
        {
            _wheatCounter += _peasantCounter * 3;

            if (_hirePeasant.interactable == false && _wheatCounter >= _peasentPrice && _isRecruitmentingOfPeasant == false)
                _hirePeasant.interactable = true;

            if (_hireWarrior.interactable == false && _wheatCounter >= _warriorPrice && _isRecruitmentingOfWarrior == false)
                _hireWarrior.interactable = true;
        }

        if (_subtractFromWheatWatchHandler.isTick)
        {
            // 2 - это то, сколько пшена съедает каждый воин и крестьянин
            _wheatCounter -= (_warriorsCounter * 2 + _peasantCounter * 2);
        }

        if(_enemiesWatchHandler.isTick)
        {
            _warriorsCounter -= _counterOfEnemies;
            _counterOfSurges++;
            if (_counterOfSurges >= 4)
            {
                _counterOfEnemies += _increasingToEnemies;
                _enemiesWatchHandler._maxTime += _addTimeToNewSurge;
                _enemiesWatchHandler._currentTime = _enemiesWatchHandler._maxTime;
            }
            _enemiesSurgeCounterText.text = _counterOfSurges.ToString();
            _counterOfEnemiesInNewSurgeText.text = _counterOfEnemies.ToString();
            // тут будет проверка на отрицательное кол-во воинов - в таком случае поражение
        }

        if (_hirePeasant.interactable == true && _wheatCounter < _peasentPrice)
            _hirePeasant.interactable = false;

        if (_hireWarrior.interactable == true && _wheatCounter < _warriorPrice)
            _hireWarrior.interactable = false;

        if (_currentPeasantTimer > 0)
        {
            _currentPeasantTimer -= Time.deltaTime;
            _timerForRecruitmentPeasant.fillAmount = _currentPeasantTimer / _peasantCreateTime;
        }
        else if (_currentPeasantTimer > -1)
        {
            _hirePeasant.interactable = true;
            _currentPeasantTimer = -2;
            _timerForRecruitmentPeasant.fillAmount = 1;
            _peasantCounter++;
            _isRecruitmentingOfPeasant = false;
        }

        if (_currentWarriorTimer > 0)
        {
            _currentWarriorTimer -= Time.deltaTime;
            _timerForRecruitmentWarrior.fillAmount = _currentWarriorTimer / _warriorCreateTime;
        }
        else if (_currentWarriorTimer > -1)
        {
            _hireWarrior.interactable = true;
            _currentWarriorTimer = -2;
            _timerForRecruitmentWarrior.fillAmount = 1;
            _warriorsCounter++;
            _isRecruitmentingOfWarrior = false;
        }

        UpdateText();
    }

    private void UpdateText()
    {
        _wheatCounterText.text = _wheatCounter.ToString();
        _peasantCounterText.text = _peasantCounter.ToString();
        _warriorsCounterText.text = _warriorsCounter.ToString();
    }

    public void HirePeasant()
    {
        _hirePeasant.interactable = false;
        _currentPeasantTimer = _peasantCreateTime;
        _wheatCounter -= _peasentPrice;
        _isRecruitmentingOfPeasant = true;
    }

    public void HireWarrior()
    {
        _hireWarrior.interactable = false;
        _currentWarriorTimer = _warriorCreateTime;
        _wheatCounter -= _warriorPrice;
        _isRecruitmentingOfWarrior = true;
    }
}
