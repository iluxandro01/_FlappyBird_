using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Bird>(out var bird))
        {
            ScoreHandler.Instance.AddPoint();
        }
    }
}
