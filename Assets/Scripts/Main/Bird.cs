using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Bird : MonoBehaviour
{
    [SerializeField] private ClickZone _clickZone;
    
    [Space(10)]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotateSpeed;
    
    [Space(10)]
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private AudioSource _dieSound;
    
    private Rigidbody2D _rigidbody;
    
    private Animator _animator;
    private static readonly int StartGameAnimationState = Animator.StringToHash("FlyingBird");

    public event Action ONDied;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _clickZone.ONClicked += Jump;
    }

    public void OnStartGame()
    {
        _animator.Play(StartGameAnimationState);
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        _animator.applyRootMotion = true;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.eulerAngles = new Vector3(0, 0, _rigidbody.velocity.y * _rotateSpeed);
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * _jumpForce;
        _jumpSound.Play();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }

    private void Die()
    {
        ONDied?.Invoke();
        _hitSound.Play();
        _dieSound.Play();
    }

    private void OnDestroy()
    {
        _clickZone.ONClicked -= Jump;
    }
}