using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ScoreHandler.Instance.ONScoreChanged += UpdateText;
    }

    private void UpdateText(int value)
    {
        _textMeshProUGUI.text = TMPFormatter.FormatNumbersToSpriteText(value);
    }

    private void OnDestroy()
    {
        ScoreHandler.Instance.ONScoreChanged -= UpdateText;
    }
}
    