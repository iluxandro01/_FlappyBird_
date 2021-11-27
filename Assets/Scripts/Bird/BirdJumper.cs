using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private ClickZone _clickZone;
    [SerializeField] private BirdAudio _birdAudio;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _clickZone.ONClicked += Jump;
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * _jumpForce;
        _birdAudio.PlayJumpSound();
    }

    private void OnDisable()
    {
        _clickZone.ONClicked -= Jump;
    }
}