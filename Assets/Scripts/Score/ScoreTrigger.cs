using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>())
        {
            ScoreHandler.Instance.AddPoint();
        }
    }
}
