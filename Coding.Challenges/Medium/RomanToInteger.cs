using System.Text;

namespace Coding.Challenges.Medium;

/*
 * Difficulty: Medium
 * Problem:
 *  Given a string s representing a roman numeral. Convert s into an integer.
 * Note:
 *  s is guaranteed to be within the range from 1 to 3999.
 */

public class RomanToInteger
{
    private static readonly Dictionary<char, int> RomanMap = new()
    {
        ['I'] = 1,
        ['V'] = 5,
        ['X'] = 10,
        ['L'] = 50,
        ['C'] = 100,
        ['D'] = 500,
        ['M'] = 1000
    };

    public static int ConvertRomanToInt(string roman)
    {
        if (string.IsNullOrWhiteSpace(roman))
            throw new ArgumentException("Input must be a non-empty Roman numeral.", nameof(roman));

        var result = 0;
        for (var i = roman.Length - 1; i >= 0; i--)
        {
            var currentChar = char.ToUpperInvariant(roman[i]);

            if (!RomanMap.TryGetValue(currentChar, out var currentValue))
                throw new ArgumentException($"Invalid Roman numeral character '{roman[i]}'.", nameof(roman));

            if (i < roman.Length - 1)
            {
                var nextChar = char.ToUpperInvariant(roman[i + 1]);
                var nextValue = RomanMap[nextChar];

                if (currentValue < nextValue)
                    result -= currentValue;
                else
                    result += currentValue;
            }
            else
            {
                result += currentValue;
            }
        }

        return result;
    }

    public static string ConvertIntToRoman(int number)
    {
        if (number is < 1 or > 3999)
            throw new ArgumentOutOfRangeException(nameof(number), "Input must be between 1 and 3999.");

        var romanNumerals = new[]
        {
            (Value: 1000, Symbol: "M"),
            (Value: 900, Symbol: "CM"),
            (Value: 500, Symbol: "D"),
            (Value: 400, Symbol: "CD"),
            (Value: 100, Symbol: "C"),
            (Value: 90, Symbol: "XC"),
            (Value: 50, Symbol: "L"),
            (Value: 40, Symbol: "XL"),
            (Value: 10, Symbol: "X"),
            (Value: 9, Symbol: "IX"),
            (Value: 5, Symbol: "V"),
            (Value: 4, Symbol: "IV"),
            (Value: 1, Symbol: "I")
        };

        var result = new StringBuilder();

        foreach (var (value, symbol) in romanNumerals)
            while (number >= value)
            {
                result.Append(symbol);
                number -= value;
            }

        return result.ToString();
    }
}