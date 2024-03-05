using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Builder : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private GameObject[] _details;

    private List<string> _steps = new List<string>();
    private int _number = 0;
    private int _minValue = 0;
    private int _maxValue;

    public event Action<int> StepChanged;

    private void Start()
    {
        _maxValue = _details.Length;
        _steps.Add("Для начала нажмите 'Следующий шаг'");
        _steps.Add("Открутите болты на верхней крышке");
        _steps.Add("Слегка преподнимите крышку.От крышки идут два провода, отсоедините их");
        _steps.Add("Открутите полощадку на которой установлен приёмник пульта, отсоедините разъём");
        _steps.Add("Открутите видеопередатчик, отсоедините разъём");
        _steps.Add("Отсоедините usb, 3.5 jack и pbd разъёмы от OrangePi, открутите болты и снимите его");
        _steps.Add("Отсоедините полетный контроллер от белого шлейфа, открутите болты и снимите его");
        _steps.Add("Отсоедините шлейф");
        _steps.Add("Отсоедините регулятор оборотов от вентилятора и двигателей и снимите его");
        _steps.Add("Конец разборки");

        _textField.text = _steps[_number];
    }

    public void Next()
    {
        
        if (_number != _maxValue)
        {
            _details[_number].SetActive(false);
        }

        _number = Mathf.Clamp(_number + 1, _minValue, _maxValue);

        _textField.text = _steps[_number];
        StepChanged?.Invoke(_number);
    }

    public void Preceding()
    {
        _number = Mathf.Clamp(_number - 1, _minValue, _maxValue);
        _details[_number].SetActive(true);
        _textField.text = _steps[_number];
        StepChanged?.Invoke(_number);
    }

    public void ToStart()
    {
        for (int i = _number; i > 0; i--)
        {
            if(i == _maxValue)
            {
                i = _maxValue - 1;
            }
            _details[i].SetActive(true);
        }

        _number = 0;
        _textField.text = _steps[_number];
        StepChanged?.Invoke(_number);
    }
}
