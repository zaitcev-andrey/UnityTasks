using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField] private InputField _field1;
    [SerializeField] private InputField _field2;
    [SerializeField] private Text _result;

    private float _number1 = 0, _number2 = 0;

    private bool IsCorrectReadDataWithInputField()
    {
        if(string.IsNullOrEmpty( _field1.text) || string.IsNullOrEmpty(_field2.text))
        {
            _result.text = "Вы не ввели оба числа";
            return false;
        }
        _number1 = Convert.ToSingle(_field1.text);
        _number2 = Convert.ToSingle(_field2.text);
        return true;
    }

    public void SumButton()
    {
        if(IsCorrectReadDataWithInputField())
            _result.text = (_number1 + _number2).ToString();
    }

    public void SubtractButton()
    {
        if (IsCorrectReadDataWithInputField())
            _result.text = (_number1 - _number2).ToString();
    }

    public void MultButton()
    {
        if (IsCorrectReadDataWithInputField())
            _result.text = (_number1 * _number2).ToString();
    }

    public void DivButton()
    {
        if (IsCorrectReadDataWithInputField())
        {
            if (_number2 != 0)
                _result.text = (_number1 / _number2).ToString();
            else _result.text = "Внимание: попытка деления на ноль";
        }
    }
}
