using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
        _score += 100;
        _score += Random.Range(0, 9);
        ONScoreChanged?.Invoke(_score);
    }
}