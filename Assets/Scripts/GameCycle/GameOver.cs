using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


[Serializable]
public class Medal
{
    public GameObject _medal;
    public int _scoreToReach;
}

public class GameOver : MonoBehaviour
{
    [SerializeField] private Medal[] _medals;
    
    [Space(10)] 
    [SerializeField] private TextMeshProUGUI _score;
    
    [Space(10)] 
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private GameObject _newBestScoreLabel;

    [Space(10)] 
    [SerializeField] private Fader _fader;
    [SerializeField] private Pauser _pauser;

    [Space(10)] 
    [SerializeField] private Bird _bird;

    private void Start()
    {
        _fader.FadeIn(0);
        _bird.ONDied += OpenWindow;
    }

    private void OpenWindow()
    {
        _pauser.ChangeState();
        _fader.FadeOut();

        ShowMedal();
        ShowScore();
        ShowBestScore();
    }

    private void ShowMedal()
    {
        foreach (var medal in _medals)
        {
            medal._medal.gameObject.SetActive(false);
        }

        var biggerMedal = _medals.Last(medal => ScoreHandler.Instance.Score >= medal._scoreToReach);
        biggerMedal._medal.SetActive(true);
    }

    private void ShowScore()
    {
        _score.text = TMPFormatter.FormatNumbersToSpriteText(ScoreHandler.Instance.Score);
    }

    private void ShowBestScore()
    {
        ScoreHandler.Instance.GetBestScore(out int bestScore, out bool isBestScore);
        
        _bestScore.text = TMPFormatter.FormatNumbersToSpriteText(bestScore);
        _newBestScoreLabel.gameObject.SetActive(isBestScore);
    }

    public void ReloadLevel()
    {
        _pauser.ChangeState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        _bird.ONDied -= OpenWindow;
    }
}