using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private bool _isPaused = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {                
                _pauseMenu.SetActive(false);
                _isPaused = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
            }
            else
            {               
                _pauseMenu.SetActive(true);
                _isPaused = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
            }
        }
    }

    public void RestartGameOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
