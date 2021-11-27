using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    [SerializeField] private BirdAudio _birdAudio;
    [SerializeField] private BirdAnimation _birdAnimation;
    
    private Rigidbody2D _rigidbody;
    
    public event Action ONDied;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnStartGame()
    {
        _birdAnimation.OnStartGame();
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }

    private void Die()
    {
        ONDied?.Invoke();
        
        _birdAudio.PlayDieSound();
    }
}