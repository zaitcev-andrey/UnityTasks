using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private ManagerForDeathCanvas _manager;

    private void OnTriggerEnter(Collider other)
    {
        _manager = FindObjectOfType<ManagerForDeathCanvas>();
        _manager.SetActiveDeathScreen();
    }
}
