using System;
using System.Collections.Generic;
using System.Text;

public static class TMPFormatter
{
    public static String FormatNumbersToSpriteText(int value, string template = "<sprite index={0:D}>")
    {
        var stack = DivideNumbers(value);
        var resultString = FormatNumbers(stack, template);
        return resultString;
    }

    private static Stack<int> DivideNumbers(int value)
    {
        Stack<int> stack = new Stack<int>();

        while (value > 0)
        {
            stack.Push(value % 10);
            value /= 10;
        }

        return stack;
    }

    private static string FormatNumbers(Stack<int> numbers, string template)
    {
        StringBuilder resultStringBuilder = new StringBuilder();

        foreach (var number in numbers)
        {
            resultStringBuilder.AppendFormat(template, number);
        }

        return resultStringBuilder.ToString();
    }
}