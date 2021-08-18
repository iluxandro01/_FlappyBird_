using UnityEngine;

enum Direction
{
    Left = -1,
    Right = 1
}

public class PipeGroup : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Direction _direction;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * (int) _direction, 0, 0);
    }
}