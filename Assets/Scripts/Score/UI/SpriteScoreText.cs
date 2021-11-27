using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SpriteScoreText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    
    public void UpdateText(int value)
    {
        _text.text = TMPFormatter.FormatNumbersToSpriteText(value);
    }
}
    