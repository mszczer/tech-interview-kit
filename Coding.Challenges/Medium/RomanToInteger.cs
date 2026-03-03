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
    private static readonly Dictionary<char, int> RomanMap = new Dictionary<char, int>
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
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
}