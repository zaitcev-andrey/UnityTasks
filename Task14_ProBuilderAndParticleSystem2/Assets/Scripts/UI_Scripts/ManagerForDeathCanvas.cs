using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerForDeathCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _canvasForDeath;

    private ManagerForCanvasOnLevels _canvasForPause;

    private void Start()
    {
        _canvasForPause = GetComponent<ManagerForCanvasOnLevels>();
    }

    public void SetActiveDeathScreen()
    {
        _canvasForDeath.SetActive(true);
        _canvasForPause._isGameOver = true;
        Cursor.visible = true;
        Time.timeScale = 0.0f;
    }
}
