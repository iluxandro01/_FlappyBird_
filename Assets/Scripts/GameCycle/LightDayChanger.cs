using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class LightDay
{
    public PipeGroup _pipeGroup;
    public Sprite _backGround;
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

    private void Start()
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
        _pipeGroupFactory.SetPipeGroup(_currentLightDay._pipeGroup);
        _backGround.sprite = _currentLightDay._backGround;
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
}