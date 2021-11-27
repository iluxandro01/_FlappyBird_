using UnityEngine;

public class ScoreHandlerAudio : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _scoreHandler.ONScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _audioSource.Play();
    }

    private void OnDisable()
    {
        _scoreHandler.ONScoreChanged -= OnScoreChanged;
    }
}