using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BirdAnimation : MonoBehaviour
{
    private Animator _animator;
    private static readonly int StartGameAnimationState = Animator.StringToHash("FlyingBird");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnStartGame()
    {
        _animator.Play(StartGameAnimationState);
        _animator.applyRootMotion = true;
    }
}