using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ManagerForCanvasWithInformationForPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _panelAtDuringLevel;
    [SerializeField] private Text _coinsTextAtDuringLevel;
    [SerializeField] private Text _timeTextAtDuringLevel;

    [SerializeField] private GameObject _panelAtEndLevel;
    [SerializeField] private Text _coinsTextAtEndLevel;
    [SerializeField] private Text _timeTextAtEndLevel;

    private LevelManager _levelManager;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        UpdateTimeAndCoins();
    }

    private void UpdateTimeAndCoins()
    {
        _coinsTextAtDuringLevel.text = $"{_levelManager.collectedCoins} / {Coins.coinsForLevels[SceneManager.GetActiveScene().buildIndex]}";
        _timeTextAtDuringLevel.text = _levelManager.timeForLevelString;
    }

    public void SwitchInformation()
    {
        _panelAtDuringLevel.SetActive(false);
        _coinsTextAtEndLevel.text = _coinsTextAtDuringLevel.text;
        _timeTextAtEndLevel.text = _timeTextAtDuringLevel.text;
        _panelAtEndLevel.SetActive(true);
    }
}
