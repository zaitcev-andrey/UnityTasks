using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerForCanvasOnLevels : MonoBehaviour
{
    [SerializeField] private GameObject _canvasForPause;
    private bool _isPaused = false;
    public bool _isGameOver = false;

    private void Start()
    {
        _canvasForPause.SetActive(false);
    }
    void Update()
    {
        EscapeHandler();
    }

    public void EscapeHandler()
    {
        if (!_isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                {
                    Cursor.visible = false;
                    ContinueButtonOnClick();
                }
                else
                {
                    Cursor.visible = true;
                    _isPaused = true;
                    Time.timeScale = 0;
                    _canvasForPause.SetActive(true);
                }
            }
        }
    }

    public void ContinueButtonOnClick()
    {
        Cursor.visible = false;
        _isPaused = false;
        Time.timeScale = 1;
        _canvasForPause.SetActive(false);
    }

    public void RestartLevelButtonOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void BackToMainMenuButtonOnClick()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
