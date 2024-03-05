using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMover : MonoBehaviour
{
    [SerializeField] private Builder _builder;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _builder.StepChanged += ChangePosition;
    }

    private void OnDisable()
    {
        _builder.StepChanged -= ChangePosition;
    }

    private void ChangePosition(int number)
    {
        _animator.SetInteger("State", number);
    }
}
