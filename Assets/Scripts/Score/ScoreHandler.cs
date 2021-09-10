using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance { get; private set; }

    public event Action<int> ONScoreChanged;
    private int _score;

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
        ONScoreChanged?.Invoke(_score);
    }
}