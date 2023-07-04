using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Если нужно остановить игру и подвести итог в конце уровня
    private ManagerForWinCanvasOnLastLevel _manager;
    private void OnTriggerEnter(Collider other)
    {
        _manager = FindObjectOfType<ManagerForWinCanvasOnLastLevel>();
        _manager.SetActiveWinScreen();
    }
}
