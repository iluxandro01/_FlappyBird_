using UnityEngine;

public class ScoreHandlerPresenter : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private SpriteScoreText _spriteScoreText;

    private void OnEnable()
    {
        _scoreHandler.ONScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _spriteScoreText.UpdateText(score);
    }

    private void OnDisable()
    {
        _scoreHandler.ONScoreChanged -= OnScoreChanged;
    }
}