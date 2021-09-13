using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Fader : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    
    public void FadeIn(float duration = 0.25f)
    {
        StartCoroutine(Fade(1, 0, duration));
    }

    public void FadeOut(float duration = 0.25f)
    {
        StartCoroutine(Fade(0, 1, duration));
    }

    private IEnumerator Fade(float startValue, float endValue, float duration, bool useUnscaledTime = true)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float normalizedTime = elapsedTime / duration;
            
            _canvasGroup.alpha = Mathf.Lerp(startValue, endValue, normalizedTime);

            var deltaTime = useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            elapsedTime += deltaTime;
            
            yield return null;
        }

        _canvasGroup.alpha = endValue;
    }
}