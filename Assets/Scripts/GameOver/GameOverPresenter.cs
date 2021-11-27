using UnityEngine;

public class GameOverPresenter : MonoBehaviour
{
    [SerializeField] private GameOverLogic _gameOverLogic;
    [SerializeField] private GameOverView _gameOverView;
    [SerializeField] private GameOverModel _gameOverModel;

    private void OnEnable()
    {
        _gameOverLogic.OnBirdDied += OnBirdDied;
        _gameOverView.OnClickOkButton += OnClickOkButton;
    }

    private void OnBirdDied()
    {
        var score = _gameOverModel.Score;
        var bestScore = _gameOverModel.BestScore;

        _gameOverView.Open(score, bestScore.Score, bestScore.IsBest);
    }

    private void OnClickOkButton()
    {
        _gameOverLogic.ReloadLevel();
    }

    private void OnDisable()
    {
        _gameOverLogic.OnBirdDied += OnBirdDied;
        _gameOverView.OnClickOkButton += OnClickOkButton;
    }
}