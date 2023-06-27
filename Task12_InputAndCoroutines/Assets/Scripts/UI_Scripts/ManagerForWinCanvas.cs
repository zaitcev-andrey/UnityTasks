using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerForWinCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _canvasForWin;
    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _timeText;

    private ManagerForCanvasOnLevels _canvasForPause;
    private GameManager _gameManager;

    private void Start()
    {
        _canvasForPause = GetComponent<ManagerForCanvasOnLevels>();
        _gameManager = FindObjectOfType<GameManager>();
    }
    public void SetActiveWinScreen()
    {
        _canvasForWin.SetActive(true);
        _canvasForPause._isGameOver = true;
        
        _coinsText.text = $"{_gameManager.collectedCoins} / {Coins.coinsForLevels[SceneManager.GetActiveScene().buildIndex]}";
        _timeText.text = $"{Math.Round(_gameManager.timeForLevel, 2)}";

        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void GoToNextLevelOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
