using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Builder : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private GameObject[] _details;

    private List<string> _steps = new List<string>();
    private int _number = 0;
    private int _minValue = 0;
    private int _maxValue;

    public event Action<int,int> StepChanged;

    private void Start()
    {
        _maxValue = _details.Length;
        _steps.Add("��� ������ ������� '��������� ���'");
        _steps.Add("��������� ����� � ������� ����������");
        _steps.Add("��������� ����� �� ������� ������");
        _steps.Add("������ ������������ ������.�� ������ ���� ��� �������, ����������� ��");
        _steps.Add("��������� ���������, �� ������� ���������� ������� ������, ����������� ������");
        _steps.Add("��������� ���������������, ����������� ������");
        _steps.Add("����������� usb, 3.5 jack � pbd ������� �� OrangePi, ��������� ����� � ������� ���");
        _steps.Add("����������� �������� ���������� �� ������ ������ � ���������� ��������, ��������� ����� � ������� ���");
        _steps.Add("����������� �����");
        _steps.Add("����������� ��������� �������� �� ����������� � ���������� � ������� ���");
        _steps.Add("����� ��������");

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
        StepChanged?.Invoke(_number,1);
    }

    public void Preceding()
    {
        _number = Mathf.Clamp(_number - 1, _minValue, _maxValue);
        _details[_number].SetActive(true);
        _textField.text = _steps[_number];
        StepChanged?.Invoke(_number,-1);
    }

    public void ToStart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
