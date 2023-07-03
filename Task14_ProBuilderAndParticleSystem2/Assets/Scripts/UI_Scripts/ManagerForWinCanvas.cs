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
    private LevelManager _levelManager;

    private void Start()
    {
        _canvasForPause = GetComponent<ManagerForCanvasOnLevels>();
        _levelManager = FindObjectOfType<LevelManager>();
    }
    public void SetActiveWinScreen()
    {
        _canvasForWin.SetActive(true);
        _canvasForPause._isGameOver = true;
        
        _coinsText.text = $"{_levelManager.collectedCoins} / {Coins.coinsForLevels[SceneManager.GetActiveScene().buildIndex]}";
        _timeText.text = _levelManager.timeForLevelString;

        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void GoToNextLevelOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
