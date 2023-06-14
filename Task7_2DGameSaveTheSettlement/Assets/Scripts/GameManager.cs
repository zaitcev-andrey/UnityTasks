using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // для перезапуска игры

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

    // Для конца игры
    // По умолчанию всё настроено для поражения, поэтому подготавливаем все компоненты для смены на победу
    // (152, 64, 64) - цвет для поражения
    // (102, 152, 64) - цвет победы
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Image _imageWithStats;
    [SerializeField] private Sprite _greenImageForWin;        
    [SerializeField] private Text _statsWithNumbersForGameOver;
    [SerializeField] private Text _gameOverText;

    [SerializeField] private GameObject _pauseScreen;

    [SerializeField] private Button _switchSoundButton;
    private Image _currentSpriteOfSoundButton;
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    [SerializeField] private AudioSource _buttonClickSound;
    [SerializeField] private AudioSource _enviromentMusic;
    [SerializeField] private AudioSource _foodSound;
    [SerializeField] private AudioSource _wheatSound;
    [SerializeField] private AudioSource _battleSound;

    private int _wheatCounter;
    private int _peasantCounter = 2;
    private int _warriorsCounter;

    private float _peasantCreateTime = 5;
    private float _currentPeasantTimer = -2;
    private float _warriorCreateTime = 5;
    private float _currentWarriorTimer = -2;

    private int _peasentPrice = 3;
    private int _warriorPrice = 5;

    private int _numberOfDeathWarriors;
    private int _numberOfAllHiringWarriors;
    private int _numberOfPassedSurges;

    private bool _isRecruitmentingOfPeasant = false;
    private bool _isRecruitmentingOfWarrior = false;

    private int _increasingToEnemies = 2;
    private int _counterOfSurges = 1;
    private int _counterOfEnemies = 0;
    private float _addTimeToNewSurge;

    private int _wheatForWin = 400;
    private int _peasantForWin = 30;

    private bool isPause = false;

    void Start()
    {
        _peasantCounterText.text = _peasantCounter.ToString();
        _addTimeToNewSurge = _enemiesWatchHandler._maxTime * 0.6f;

        _currentSpriteOfSoundButton = _switchSoundButton.GetComponent<Image>();
        _currentSpriteOfSoundButton.sprite = _soundOn;
    }

    void Update()
    {
        if(isPause == false && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOnClick();
        }
        else if (isPause == true && Input.GetKeyDown(KeyCode.Escape))
        {
            ContinueOnCLick();
        }

        if(_addToWheatWatchHandler.isTick)
        {
            _wheatCounter += _peasantCounter * 3;
            _wheatSound.Play();

            if (_hirePeasant.interactable == false && _wheatCounter >= _peasentPrice && _isRecruitmentingOfPeasant == false)
                _hirePeasant.interactable = true;

            if (_hireWarrior.interactable == false && _wheatCounter >= _warriorPrice && _isRecruitmentingOfWarrior == false)
                _hireWarrior.interactable = true;
        }

        if (_subtractFromWheatWatchHandler.isTick)
        {
            // 2 - это то, сколько пшена съедает каждый воин и крестьянин
            _wheatCounter -= (_warriorsCounter * 2 + _peasantCounter * 2);
            _foodSound.Play();
        }

        if(_enemiesWatchHandler.isTick)
        {
            _battleSound.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
            _battleSound.Play();           

            if (_warriorsCounter >= _counterOfEnemies)
                _numberOfDeathWarriors += _counterOfEnemies;
            else _numberOfDeathWarriors += _warriorsCounter;

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
            _numberOfAllHiringWarriors++;
            _isRecruitmentingOfWarrior = false;
        }

        UpdateText();

        if(_warriorsCounter < 0)
        {
            _numberOfPassedSurges = _counterOfSurges - 2;
            ActiveGameOverScreen();
        }
        else if (_wheatCounter >= _wheatForWin || _peasantCounter >= _peasantForWin)
        {
            // Сначала меняем цвет экранов для победы на зелёный
            _gameOverScreen.GetComponent<Image>().color = new Color(102f / 255, 152f / 255, 64f / 255, 180f / 255);
            _imageWithStats.sprite = _greenImageForWin;
            _gameOverText.text = "Вы победили!!!";
            _numberOfPassedSurges = _counterOfSurges - 1;
            ActiveGameOverScreen();
        }

    }

    private void UpdateText()
    {
        _wheatCounterText.text = _wheatCounter.ToString();
        _peasantCounterText.text = _peasantCounter.ToString();
        if (_warriorsCounter >= 0)
            _warriorsCounterText.text = _warriorsCounter.ToString();
        else _warriorsCounterText.text = "0";
    }

    private void ActiveGameOverScreen()
    {
        _statsWithNumbersForGameOver.text =
                $"{Math.Round(Time.time)}\n\n{_wheatCounter}\n\n{_peasantCounter}\n\n{_numberOfAllHiringWarriors}\n\n\n{_numberOfPassedSurges}\n\n{_numberOfDeathWarriors}";
        Time.timeScale = 0;
        _gameOverScreen.SetActive(true);
    }

    public void HirePeasant()
    {
        _buttonClickSound.Play();
        _hirePeasant.interactable = false;
        _currentPeasantTimer = _peasantCreateTime;
        _wheatCounter -= _peasentPrice;
        _isRecruitmentingOfPeasant = true;
    }

    public void HireWarrior()
    {
        _buttonClickSound.Play();
        _hireWarrior.interactable = false;
        _currentWarriorTimer = _warriorCreateTime;
        _wheatCounter -= _warriorPrice;
        _isRecruitmentingOfWarrior = true;
    }

    public void SwitchSound()
    {
        if (_currentSpriteOfSoundButton.sprite == _soundOn)
        {
            _currentSpriteOfSoundButton.sprite = _soundOff;
            _enviromentMusic.Pause();
            _buttonClickSound.volume = 0f;
            _foodSound.volume = 0f;
            _wheatSound.volume = 0f;
            _battleSound.volume = 0f;
        }

        else
        {
            _currentSpriteOfSoundButton.sprite = _soundOn;
            _enviromentMusic.Play();
            _buttonClickSound.volume = 0.3f;
            _foodSound.volume = 0.15f;
            _wheatSound.volume = 0.2f;
            _battleSound.volume = 0.05f;
        }
    }

    public void PauseOnClick()
    {
        isPause = true;
        _pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueOnCLick()
    {
        isPause = false;
        _pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void PlayAndPauseOnClick()
    {
        if (isPause)
            ContinueOnCLick();
        else PauseOnClick();
    }
}
