using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Builder _builder;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _builder.StepChanged += ChangeState;
    }

    private void OnDisable()
    {
        _builder.StepChanged -= ChangeState;
    }

    private void ChangeState(int number,int none)
    {
        _animator.SetInteger("State", number);
    }
}
