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
        IsOpen = !IsOpen;
        _animator.SetBool("IsOpen", IsOpen);
    }
}
