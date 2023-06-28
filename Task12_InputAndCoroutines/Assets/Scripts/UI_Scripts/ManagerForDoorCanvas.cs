using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerForDoorCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _canvasForDoor;

    public void SetActiveDoorHint()
    {
        _canvasForDoor.SetActive(true);
    }

    public void SetDeactiveDoorHint()
    {
        _canvasForDoor.SetActive(false);
    }
}
