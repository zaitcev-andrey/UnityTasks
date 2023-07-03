using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int collectedCoins = 0;
    public float timeForLevel = 0;
    public string timeForLevelString = "";
    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        timeForLevel += Time.deltaTime;
        if (timeForLevel < 60)
            timeForLevelString = $"{Math.Round(timeForLevel)}";
        else timeForLevelString = $"{Math.Floor(timeForLevel / 60)}.{(Math.Round(timeForLevel) % 60)}";
    }
}
