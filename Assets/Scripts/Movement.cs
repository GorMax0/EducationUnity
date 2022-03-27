using UnityEngine;

[RequireComponent(typeof(Animator),typeof(Rigidbody))]
public class Movement : MonoBehaviour
{    
    [SerializeField] private float _speed;
    [SerializeField] private float _mouseSensitivity;

    private Vector3 _direction;
    private float _rotateX;    
    private Rigidbody _rigidbody;
    private Animator _animator;      

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;        
    }

    private void FixedUpdate()
    {
        Move();
        RotateWithMouse();        
    }

    private void Move()
    {
       var horizontal = Input.GetAxis("Horizontal");
       var vertical = Input.GetAxis("Vertical");

        _direction = transform.right * horizontal + transform.forward * vertical;
        _rigidbody.velocity = _direction * _speed;        
        PlayAnimation(horizontal,vertical);
    }

    private void RotateWithMouse()
    {
        _rotateX = Input.GetAxis("Mouse X");
        transform.Rotate(_rotateX * new Vector3(0,1,0) * _mouseSensitivity);
    }

    private void PlayAnimation(float horizontal, float vertical)
    {
        _animator.SetBool("Walk", _direction != Vector3.zero);
        _animator.SetFloat("WalkHorizontal", horizontal);
        _animator.SetFloat("WalkVertical", vertical);        
    }
}
