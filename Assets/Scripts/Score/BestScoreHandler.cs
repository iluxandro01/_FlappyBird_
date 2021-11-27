using UnityEngine;

public class BestScoreHandler : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    
    private const string BestScoreKey = "BestScore";

    public void GetBestScore(out int bestScore, out bool isBestScore)
    {
        var currentScore = _scoreHandler.Score;
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);

        isBestScore = currentScore > bestScore;
        
        if (isBestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }
        
    }
}