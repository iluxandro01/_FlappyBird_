using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdRotater : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 2.5f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.eulerAngles = new Vector3(0, 0, _rigidbody.velocity.y * _rotateSpeed);
    }
}