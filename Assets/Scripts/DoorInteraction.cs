using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorInteraction : MonoBehaviour
{
    private Animator _animator;

    public bool IsOpen { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeState()
    {
        const string isOpen = nameof(IsOpen);

        IsOpen = !IsOpen;
        _animator.SetBool(isOpen, IsOpen);
    }
}