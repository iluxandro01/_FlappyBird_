using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int _score;
    public int Score => _score;
    
    public event Action<int> ONScoreChanged;
    
    public void AddPoint()
    {
        _score++;
        
        ONScoreChanged?.Invoke(_score);
    }
}