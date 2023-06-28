using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnGround : MonoBehaviour
{
    [SerializeField] GameObject _gameObjectForTurnOn;

    private void OnTriggerEnter(Collider other)
    {
        _gameObjectForTurnOn.SetActive(true);
    }
}
