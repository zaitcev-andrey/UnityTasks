using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCoinCounter : MonoBehaviour
{
    private GameManager _gameManager;
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void IncreaseCounter()
    {
        _gameManager.collectedCoins++;
    }
}
