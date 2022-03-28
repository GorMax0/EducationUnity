using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    public bool IsOpen { get; private set;}

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
    }

    public void ChangeState()
    {
       const string isOpen = nameof(IsOpen);
        IsOpen = !IsOpen;
        _animator.SetBool(isOpen, IsOpen);
    }
}
