using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerForWinCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _canvasForWin;
    private ManagerForCanvasOnLevels _canvasForPause;

    private void Start()
    {
        _canvasForPause = GetComponent<ManagerForCanvasOnLevels>();
    }
    public void SetActiveWinScreen()
    {
        _canvasForWin.SetActive(true);
        _canvasForPause._isGameOver = true;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void GoToNextLevelOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
