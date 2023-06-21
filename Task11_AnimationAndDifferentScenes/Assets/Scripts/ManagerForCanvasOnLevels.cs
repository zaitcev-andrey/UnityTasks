using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerForCanvasOnLevels : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    private bool _isPaused = false;

    private void Start()
    {
        _canvas.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ContinueButtonOnClick();
            }
            else
            {
                _isPaused = true;
                Time.timeScale = 0;
                _canvas.SetActive(true);
            }
        }
    }

    public void ContinueButtonOnClick()
    {
        _isPaused = false;
        Time.timeScale = 1;
        _canvas.SetActive(false);
    }

    public void RestartLevelButtonOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenuButtonOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
