using UnityEngine;

public class GameOverModel : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private BestScoreHandler _bestScoreHandler;

    public int Score => _scoreHandler.Score;

    public BestScore BestScore
    {
        get
        {
            _bestScoreHandler.GetBestScore(out var bestScore, out var isBestScore);
            return new BestScore(isBestScore, bestScore);
        }
    }
}

public readonly struct BestScore
{
    public readonly bool IsBest;
    public readonly int Score;

    public BestScore(bool isBestScore, int bestScore)
    {
        IsBest = isBestScore;
        Score = bestScore;
    }
}