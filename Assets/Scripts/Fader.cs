using System.Collections;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private SpriteRenderer[] _spriteRenderers;
    [SerializeField] private float _duration;

    private void Start()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public void FadeOut()
    {
        foreach (var spriteRenderer in _spriteRenderers)
        {
            StartCoroutine(FadeOutRoutine(spriteRenderer));
        }
    }

    private IEnumerator FadeOutRoutine(SpriteRenderer spriteRenderer)
    {
        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            float normalizedTime = elapsedTime / _duration;

            var color = spriteRenderer.color;
            spriteRenderer.color = new Color(color.r, color.g, color.b, 1 - normalizedTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}