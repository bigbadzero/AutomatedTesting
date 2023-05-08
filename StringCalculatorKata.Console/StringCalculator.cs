using System.Text.RegularExpressions;

namespace StringCalculatorKata.Console;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        string[] delimiters = GetDelimiters(numbers);
        numbers = RemoveDelimiterLine(numbers);
        var splitNumbers = numbers.Split(delimiters, StringSplitOptions.None);
        var intList = new List<int>();

        foreach (var number in splitNumbers)
        {
            if (int.TryParse(number, out int n))
            {
                if (n < 0)
                    throw new ArgumentException($"Negatives not allowed: {string.Join(",", splitNumbers.Where(x => int.Parse(x) < 0))}");

                if (n <= 1000)
                    intList.Add(n);
            }
        }
        return intList.Sum();
    }

    private string[] GetDelimiters(string input)
    {
        string[] delimiters = { ",", "\n" };

        if (input.StartsWith("//"))
        {
            int delimiterEndIndex = input.IndexOf("\n");
            string delimiterLine = input.Substring(0, delimiterEndIndex);

            if (delimiterLine.Length > 2 && delimiterLine.StartsWith("//[") && delimiterLine.EndsWith("]"))
            {
                delimiters = delimiterLine
                    .Substring(3, delimiterLine.Length - 4)
                    .Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
                delimiters = new string[] { delimiterLine.Substring(2) };
        }
        return delimiters.Union(new string[] { "\n" }).ToArray();
    }

    private string RemoveDelimiterLine(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        if (input.StartsWith("//"))
        {
            var delimiterLineEndIndex = input.IndexOf('\n');
            if (delimiterLineEndIndex >= 0)
                return input.Substring(delimiterLineEndIndex + 1);
        }
        return input;
    }
}