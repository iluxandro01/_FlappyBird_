using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Medal
{
    public GameObject _medal;
    public int _scoreToReach;

    public Medal(int scoreToReach)
    {
        _scoreToReach = scoreToReach;
    }
}
public class GameOver : MonoBehaviour
{
    [SerializeField] private Medal[] _medals;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI _score;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private GameObject _newBestScoreLabel;
    
    [SerializeField] private Bird _bird;
    [SerializeField] private Pauser _pauser;
    private int _lastScore;

    private void Start()
    {
        _bird.ONDied += ShowMedal;
        ScoreHandler.Instance.ONScoreChanged += OnScoreChanged;
        gameObject.SetActive(false);
    }

    private void OnScoreChanged(int score)
    {
        _lastScore = score;
    }

    public void ShowMedal()
    {
        gameObject.SetActive(true);
        _pauser.ChangeState();
        
        foreach (var medal in _medals)
        {
            medal._medal.gameObject.SetActive(false);
        }

        var last = _medals.Last(medal => _lastScore >= medal._scoreToReach);
        last._medal.SetActive(true);
    }

    private void OnDestroy()
    {
        ScoreHandler.Instance.ONScoreChanged -= OnScoreChanged;
        _bird.ONDied -= ShowMedal;
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
