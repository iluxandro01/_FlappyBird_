using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MedalView
{
    [SerializeField] private GameObject _medal;
    [SerializeField] private int _scoreToReach;

    public GameObject Medal => _medal;
    public int ScoreToReach => _scoreToReach;
}

[RequireComponent(typeof(Fader))]
public class GameOverView : MonoBehaviour
{
    [SerializeField] private MedalView[] _medals;
    [Space(10)] 
    [SerializeField] private SpriteScoreText _score;
    [Space(10)] 
    [SerializeField] private SpriteScoreText _bestScore;
    [SerializeField] private GameObject _newBestScoreLabel;
    [SerializeField] private Button _okButton;

    private Fader _fader;

    public event Action OnClickOkButton;

    private void Awake()
    {
        _fader = GetComponent<Fader>();
    }

    private void OnEnable()
    {
        _okButton.onClick.AddListener(ClickOkButton);
    }

    private void ClickOkButton()
    {
        OnClickOkButton?.Invoke();
    }

    private void Start()
    {
        _fader.FadeIn(0);
    }

    public void Open(int score, int bestScore, bool isBestScore)
    {
        _fader.FadeOut();

        ShowMedal(score);
        ShowScore(score);
        ShowBestScore(bestScore, isBestScore);
    }

    private void ShowMedal(int score)
    {
        DisableAllMedals();
        ShowBiggestMedal(score);
    }

    private void DisableAllMedals()
    {
        foreach (var medal in _medals)
        {
            medal.Medal.gameObject.SetActive(false);
        }
    }

    private void ShowBiggestMedal(int score)
    {
        var biggestMedal = _medals.Last(medal => score >= medal.ScoreToReach);
        biggestMedal.Medal.SetActive(true);
    }

    private void ShowScore(int score)
    {
        _score.UpdateText(score);
    }

    private void ShowBestScore(int bestScore, bool isBestScore)
    {
        _bestScore.UpdateText(bestScore);
        _newBestScoreLabel.gameObject.SetActive(isBestScore);
    }

    private void OnDisable()
    {
        _okButton.onClick.RemoveListener(ClickOkButton);
    }
}