using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private ManagerForWinCanvasOnLastLevel _manager;
    private void OnTriggerEnter(Collider other)
    {
        _manager = FindObjectOfType<ManagerForWinCanvasOnLastLevel>();
        _manager.SetActiveWinScreen();
    }
}
