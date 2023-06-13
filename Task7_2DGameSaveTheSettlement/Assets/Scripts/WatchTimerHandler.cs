using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchTimerHandler : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    public bool isTick;

    private float _currentTime;
    private Image _sourceImage;

    void Start()
    {
        _currentTime = _maxTime;
        _sourceImage = GetComponent<Image>();
    }

    void Update()
    {
        _currentTime -= Time.deltaTime;
        isTick = false;

        if(_currentTime <= 0)
        {
            isTick = true;
            _currentTime = _maxTime;
        }

        _sourceImage.fillAmount = _currentTime / _maxTime;
    }
}
