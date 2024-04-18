using UnityEngine;

public class OutlineController : MonoBehaviour
{
    [SerializeField] private GameObject[] _outlines;
    [SerializeField] private Builder _builder;

    private Outline _outline;

    private int _number = 0;
    private int _minValue = 0;
    private int _maxValue;

    private void Start()
    {
        _maxValue = _outlines.Length;

        foreach (var item in _outlines)
        {
            Outline outline = item.GetComponent<Outline>();
            outline.OutlineColor = new Color(1f, 0f, 0.7f, 1.0f);
            //outline.OutlineMode = Outline.Mode.OutlineVisible;
        }
    }

    private void OnEnable()
    {
        _builder.StepChanged += DrawOutline;
    }

    private void OnDisable()
    {
        _builder.StepChanged -= DrawOutline;
    }

    private void DrawOutline(int none,int state)
    {
        if (state == 1)
        {
            TurnOutline(false);
            _number = Mathf.Clamp(_number + 1, _minValue, _maxValue);
            TurnOutline(true);
        }
        else if (state == -1)
        {
            TurnOutline(false);
            _number = Mathf.Clamp(_number - 1, _minValue, _maxValue);
            TurnOutline(true);
        }
        else if (state == 0)
        {
            while (_number > 0)
            {
                if (_number == _maxValue)
                {
                    _number = _maxValue - 1;
                }

                TurnOutline(false);
                _number = Mathf.Clamp(_number - 1, _minValue, _maxValue);
            }
        }
    }

    private void TurnOutline(bool state)
    {
        if (_number != _maxValue)
        {
            _outline = _outlines[_number].GetComponent<Outline>();
            _outline.enabled = state;
        }
    }
}
