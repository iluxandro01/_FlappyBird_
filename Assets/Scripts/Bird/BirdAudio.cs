using UnityEngine;

public class BirdAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private AudioSource _dieSound;

    public void PlayJumpSound()
    {
        _jumpSound.Play();
    }

    public void PlayDieSound()
    {
        _dieSound.Play();
    }
}