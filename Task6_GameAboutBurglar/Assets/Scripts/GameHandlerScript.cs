using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandlerScript : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    [SerializeField] private GameObject _playerLostPanel;
    [SerializeField] private GameObject _playerWonPanel;
    [SerializeField] private Button _tool1_DrillButton;
    [SerializeField] private Button _tool2_HammerButton;
    [SerializeField] private Button _tool3_KeyButton;
    [SerializeField] private Button _tool4_SawButton;
    [SerializeField] private Button _tool5_ScrewdriverButton;

    [SerializeField] private Text _number1Text;
    [SerializeField] private Text _number2Text;
    [SerializeField] private Text _number3Text;
    [SerializeField] private Text _attemptsCounterText;

    public float currentTime;

    private float _roundValue;
    private int _num1;
    private int _num2;
    private int _num3;
    private int _attemptsCounter = 25;
    private int _startNum1 = 6;
    private int _startNum2 = 2;
    private int _startNum3 = 4;

    void Update()
    {
        currentTime -= Time.deltaTime;
        //_timerText.text = Math.Round(_currentTime, 2).ToString();
        _roundValue = Mathf.Round(currentTime);
        _timerText.text = _roundValue.ToString();

        if (_roundValue <= 15)
            _timerText.color = Color.red;
        else if (_roundValue <= 30)
            _timerText.color = Color.yellow;
        else if(_roundValue <= 60)
            _timerText.color = Color.green;

        if (_roundValue == 0)
        {
            ShowLostPanel();
        }
    }

    private void DisableInteractableOnButtons()
    {
        _tool1_DrillButton.interactable = false;
        _tool2_HammerButton.interactable = false;
        _tool3_KeyButton.interactable = false;
        _tool4_SawButton.interactable = false;
        _tool5_ScrewdriverButton.interactable = false;
    }

    private void EnableInteractableOnButtons()
    {
        _tool1_DrillButton.interactable = true;
        _tool2_HammerButton.interactable = true;
        _tool3_KeyButton.interactable = true;
        _tool4_SawButton.interactable = true;
        _tool5_ScrewdriverButton.interactable = true;
    }

    private void ShowLostPanel()
    {
        enabled = false; // чтобы Update выключился
        _playerLostPanel.SetActive(true);
        DisableInteractableOnButtons();
    }

    private void ShowWonPanel()
    {
        enabled = false; // чтобы Update выключился
        _playerWonPanel.SetActive(true);
        DisableInteractableOnButtons();
    }

    private void GetNumbers()
    {
        _num1 = int.Parse(_number1Text.text);
        _num2 = int.Parse(_number2Text.text);
        _num3 = int.Parse(_number3Text.text);
    }

    /// <summary>
    /// Эта функция обновляет значения для трёх чисел в комбинации
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <param name="value3"></param>
    private void SetNumbers(int value1, int value2, int value3)
    {
        GetNumbers();
        _number1Text.text = Mathf.Clamp(_num1 + value1, 0, 10).ToString();
        _number2Text.text = Mathf.Clamp(_num2 + value2, 0, 10).ToString();
        _number3Text.text = Mathf.Clamp(_num3 + value3, 0, 10).ToString();

        _attemptsCounter--;
        _attemptsCounterText.text = _attemptsCounter.ToString();
        if (_attemptsCounter <= 7)
            _attemptsCounterText.color = Color.red;
        else if (_attemptsCounter <= 15)
            _attemptsCounterText.color = Color.yellow;
        else if (_attemptsCounter <= 25)
            _attemptsCounterText.color = Color.green;

        if (_num1 + value1 == 5 && _num2 + value2 == 5 && _num3 + value3 == 5)
        {
            ShowWonPanel();
        }
        else if (_attemptsCounter == 0)
        {
            ShowLostPanel();
        }
    }

    public void Tool1_DrillButtonOnClick()
    {
        SetNumbers(1, -1, 0);
    }

    public void Tool2_HammerButtonOnClick()
    {
        SetNumbers(-1, 2, -1);
    }

    public void Tool3_KeyButtonOnClick()
    {
        SetNumbers(-1, 1, 1);
    }

    public void Tool4_SawButtonOnClick()
    {
        SetNumbers(1, -2, -1);
    }

    public void Tool5_ScrewdriverButtonOnClick()
    {
        SetNumbers(0, 1, 1);
    }

    public void LostAndWonPanelTryAgainButtonOnClick()
    {
        currentTime = 60f;
        _attemptsCounter = 25;
        EnableInteractableOnButtons();
        _number1Text.text = _startNum1.ToString();
        _number2Text.text = _startNum2.ToString();
        _number3Text.text = _startNum3.ToString();
        _attemptsCounterText.text = _attemptsCounter.ToString();
        _attemptsCounterText.color = Color.green;

        enabled = true; // чтобы Update заново включился

        _playerLostPanel.SetActive(false);
        _playerWonPanel.SetActive(false);
    }
}
