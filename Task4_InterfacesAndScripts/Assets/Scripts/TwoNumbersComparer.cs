using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoNumbersComparer : MonoBehaviour
{
    [SerializeField] private InputField _field1;
    [SerializeField] private InputField _field2;
    [SerializeField] private Text _result;

    private float _number1 = 0, _number2 = 0;

    public void CompareTwoNumbersButton()
    {
        if (string.IsNullOrEmpty(_field1.text) || string.IsNullOrEmpty(_field2.text))
        {
            _result.text = "Вы не ввели оба числа";
            return;
        }
        _number1 = Convert.ToSingle(_field1.text);
        _number2 = Convert.ToSingle(_field2.text);

        if (_number1 > _number2)
            _result.text = _number1.ToString();
        else if (_number1 < _number2)
            _result.text = _number2.ToString();
        else _result.text = "Числа равны";
    }
}
