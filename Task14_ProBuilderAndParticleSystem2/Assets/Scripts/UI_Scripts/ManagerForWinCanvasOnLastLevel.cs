using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerForWinCanvasOnLastLevel : MonoBehaviour
{
    [SerializeField] private GameObject _canvasForWinOnLastLevel;
    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _timeText;

    private ManagerForCanvasOnLevels _canvasForPause;
    private LevelManager _levelManager;

    private void Start()
    {
        _canvasForPause = GetComponent<ManagerForCanvasOnLevels>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    public void SetActiveWinScreen()
    {
        _canvasForWinOnLastLevel.SetActive(true);
        _canvasForPause._isGameOver = true;

        _coinsText.text = $"{_levelManager.collectedCoins} / {Coins.coinsForLevels[SceneManager.GetActiveScene().buildIndex]}";
        _timeText.text = $"{Math.Round(_levelManager.timeForLevel, 2)}";

        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
