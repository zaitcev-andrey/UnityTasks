using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCoinCounter : MonoBehaviour
{
    private LevelManager _levelManager;
    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    public void IncreaseCounter()
    {
        _levelManager.collectedCoins++;
    }
}
