using UnityEngine;

public enum Direction
{
    Left = -1,
    Right = 1
}

public class PipeGroup : MonoBehaviour
{
    [SerializeField] private ScoreTrigger _scoreTrigger;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Direction _direction;

    public void Init(ScoreHandler scoreHandler)
    {
        _scoreTrigger.Init(scoreHandler);
    }
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_moveSpeed * Time.deltaTime *  (int) _direction, 0, 0);
    }
}