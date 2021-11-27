using System;
using UnityEngine;

public class GameOverLogic : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private Pauser _pauser;
    [SerializeField] private Bird _bird;

    public event Action OnBirdDied;

    private void OnEnable()
    {
        _bird.ONDied += OnDied;
    }

    private void OnDied()
    {
        _pauser.ChangeState();
        OnBirdDied?.Invoke();
    }

    public void ReloadLevel()
    {
        _pauser.ChangeState();
        _sceneController.ReloadLevel();
    }

    private void OnDisable()
    {
        _bird.ONDied += OnDied;
    }
}