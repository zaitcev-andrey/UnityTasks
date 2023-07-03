using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterToNewLevel : MonoBehaviour
{
    private ManagerForWinCanvas _manager;
    private void OnTriggerEnter(Collider other)
    {
        _manager = FindObjectOfType<ManagerForWinCanvas>();
        _manager.SetActiveWinScreen();
    }
}
