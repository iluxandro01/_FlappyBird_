using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Bird : MonoBehaviour
{
    [SerializeField] private ClickZone _clickZone;
    [SerializeField] private GameCycle _gameCycle;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private static readonly int StartGameAnimate = Animator.StringToHash("FlyingBird");

    public event Action ONDied;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _gameCycle.ONStartGame += OnStartGame;
        _clickZone.ONClicked += Jump;
    }

    private void OnStartGame()
    {
        _animator.Play(StartGameAnimate);
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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<Pipe>() != null)
        {
            Die();
        }
    }

    private void Die()
    {
        ONDied?.Invoke();
    }

    private void OnDestroy()
    {
        _clickZone.ONClicked -= Jump;
        _gameCycle.ONStartGame -= OnStartGame;
    }
}