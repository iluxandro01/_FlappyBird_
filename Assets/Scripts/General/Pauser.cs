using System;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    private bool _isPaused;
    public event Action<bool> ONStatePauseChanged;
    
    public void ChangeState()
    {
        if (_isPaused)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
        
        ONStatePauseChanged?.Invoke(_isPaused);
    }
    
    private void Pause()
    {
        _isPaused = true;
        Time.timeScale = 0f;
    }

    private void UnPause()
    {
        _isPaused = false;
        Time.timeScale = 1f;
    }
}
