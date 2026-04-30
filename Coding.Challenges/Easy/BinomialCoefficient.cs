namespace Coding.Challenges.Easy;

/*
 * Difficulty: Easy
 * Problem:
 *  Given two integers n and r, write a function to compute the binomial coefficient "n choose r",
 *  denoted as C(n,r) or nCr. This represents the number of ways to choose r items from n items
 *  without regard to order.
 * Ideas to think:
 *  Complexity analysis, optimization using symmetry property C(n,r) = C(n,n-r)
 */
public static class BinomialCoefficient
{
    public static int CalculateNChooseR(int n, int r)
    {
        if (n < 0 || r < 0)
            throw new ArgumentException("n and r must be non-negative.");

        if (r > n)
            return 0;

        if (r == 0 || r == n)
            return 1;

        r = Math.Min(r, n - r);

        var result = 1;
        for (var i = 0; i < r; i++)
        {
            result *= n - i;
            result /= i + 1;
        }

        return result;
    }
}
