using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerForCanvasWithInformationForPlayer : MonoBehaviour
{
    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _timeText;

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
        _coinsText.text = $"{_levelManager.collectedCoins} / {Coins.coinsForLevels[SceneManager.GetActiveScene().buildIndex]}";
        _timeText.text = _levelManager.timeForLevelString;
    }
}
