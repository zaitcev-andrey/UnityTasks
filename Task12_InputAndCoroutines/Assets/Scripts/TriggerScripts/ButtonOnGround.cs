using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnGround : MonoBehaviour
{
    [SerializeField] GameObject _gameObjectForTurnOn;

    private void OnTriggerEnter(Collider other)
    {
        if(_gameObjectForTurnOn.activeSelf)
            _gameObjectForTurnOn.SetActive(false);
        else _gameObjectForTurnOn.SetActive(true);
    }
}
