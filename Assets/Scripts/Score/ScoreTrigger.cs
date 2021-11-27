using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private ScoreHandler _scoreHandler;

    public void Init(ScoreHandler scoreHandler)
    {
        _scoreHandler = scoreHandler;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            _scoreHandler.AddPoint();
        }
    }
}