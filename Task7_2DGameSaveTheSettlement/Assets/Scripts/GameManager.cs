using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WatchTimerHandler _addToWheatWatchHandler;
    [SerializeField] private WatchTimerHandler _subtractFromWheatWatchHandler;

    [SerializeField] private Text _wheatCounterText;
    [SerializeField] private Text _peasantCounterText;
    [SerializeField] private Text _warriorsCounterText;

    private int _wheatCounter;
    private int _peasantCounter;
    private int _warriorsCounter = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_addToWheatWatchHandler.isTick)
        {
            _wheatCounter += 3;
        }

        if(_subtractFromWheatWatchHandler.isTick)
        {
            _wheatCounter -= _warriorsCounter * 1; // 1 - это то, сколько пшена съедает каждый воин
        }

        _wheatCounterText.text = _wheatCounter.ToString();
    }
}
