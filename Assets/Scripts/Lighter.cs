using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Lighter : MonoBehaviour
{
    [SerializeField] private Color _targetEnd;
    [SerializeField] private Color _targetStart;
    [SerializeField] private float _speed;

    private Light _light;

    private void Awake()
    {
        _light = GetComponent<Light>();
        _targetStart = _light.color;
    }

    private void OnEnable()
    {        
        StartCoroutine(ChangeColor());
    }

    private void OnDisable()
    {
        StopCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (_light.color != _targetEnd)
        {
            _light.color = Color.Lerp(_light.color, _targetEnd, _speed);
            yield return null;
        }

        Color temp = _targetStart;
        _targetStart = _targetEnd;
        _targetEnd = temp;

        StartCoroutine(ChangeColor());
    }

}
