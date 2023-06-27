using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int collectedCoins = 0;
    public float timeForLevel = 0;
    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        timeForLevel += Time.deltaTime;
    }
}
