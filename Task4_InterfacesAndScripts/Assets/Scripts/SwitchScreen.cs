using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScreen : MonoBehaviour
{
    [SerializeField] private GameObject _calculatorPanel;
    [SerializeField] private GameObject _twoNumbersComparerPanel;

    private GameObject _currentPanel;

    void Start()
    {
        _calculatorPanel.SetActive(true);
        _twoNumbersComparerPanel.SetActive(false);
        _currentPanel = _calculatorPanel;
    }

    public void SwitchScreenButton(GameObject panel)
    {
        if (_currentPanel != null)
        {
            _currentPanel.SetActive(false);
            panel.SetActive(true);
            _currentPanel = panel;
        }
    }
}
