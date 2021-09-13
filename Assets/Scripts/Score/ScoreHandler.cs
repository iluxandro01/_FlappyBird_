using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance { get; private set; }

    private int _score;
    public int Score => _score;
    
    public event Action<int> ONScoreChanged;

    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddPoint()
    {
        _score++;
        _audioSource.Play();
        ONScoreChanged?.Invoke(_score);
    }

    public void GetBestScore(out int bestScore, out bool isBestScore)
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (_score > bestScore)
        {
            bestScore = _score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            
            isBestScore = true;
        }
        else
        {
            isBestScore = false;
        }
    }
}