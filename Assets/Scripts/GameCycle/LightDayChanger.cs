using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class LightDay
{
    [SerializeField] private PipeGroup _pipeGroup;
    [SerializeField] private Sprite _backGround;
    
    public PipeGroup PipeGroup => _pipeGroup;
    public Sprite BackGround => _backGround;
}

public class LightDayChanger : MonoBehaviour
{
    [SerializeField] private int _timeToSwap;
    [Space(10)] 
    [SerializeField] private PipeGroupFactory _pipeGroupFactory;
    [SerializeField] private SpriteRenderer _backGround;
    [Space(10)] 
    [SerializeField] private LightDay _morning;
    [SerializeField] private LightDay _night;

    private LightDay _currentLightDay;

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        float elapsedTime = 0f;
        while (true)
        {
            if (elapsedTime > _timeToSwap)
            {
                SetLightDay();
                elapsedTime = 0f;
            }

            yield return null;
            elapsedTime += Time.deltaTime;
        }
    }

    private void SetLightDay()
    {
        ChangeLightDay();
        ChangeSettings();
    }

    private void ChangeLightDay()
    {
        if (_currentLightDay == _morning)
        {
            _currentLightDay = _night;
        }
        else
        {
            _currentLightDay = _morning;
        }
    }

    private void ChangeSettings()
    {
        _pipeGroupFactory.SetPipeGroup(_currentLightDay.PipeGroup);
        _backGround.sprite = _currentLightDay.BackGround;
    }
}