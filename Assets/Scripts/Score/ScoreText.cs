using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    private const string Template = "<sprite index={0:D}>";

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
        var stack = DivideNumbers(value);
        var resultString = FormatNumbers(stack);
        
        _textMeshProUGUI.text = resultString;
    }

    private void OnDestroy()
    {
        ScoreHandler.Instance.ONScoreChanged -= UpdateText;
    }

    private Stack<int> DivideNumbers(int value)
    {
        Stack<int> stack = new Stack<int>();

        while (value > 0)
        {
            stack.Push(value % 10);
            value /= 10;
        }

        return stack;
    }

    private string FormatNumbers(Stack<int> numbers)
    {
        StringBuilder resultStringBuilder = new StringBuilder();

        foreach (var number in numbers)
        {
            resultStringBuilder.AppendFormat(Template, number);
        }

        return resultStringBuilder.ToString();
    }
}