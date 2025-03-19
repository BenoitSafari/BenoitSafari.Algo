namespace AlgoTester.Tests;

public class EvenOddTests
{
    [Theory]
    [InlineData(2, true)]
    [InlineData(3, false)]
    [InlineData(0, true)]
    [InlineData(-2, true)]
    [InlineData(-3, false)]
    public void IsEven_ShouldReturnCorrectResult(int number, bool expected) =>
        Assert.Equal(expected, EvenOdd.IsEven(number));

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 3)]
    [InlineData(new[] { 2, 4, 6, 8 }, 4, 0)]
    [InlineData(new[] { 1, 3, 5, 7 }, 0, 4)]
    public void CountEvenOdd_ShouldReturnCorrectCounts(
        int[] numbers,
        int expectedEvenCount,
        int expectedOddCount
    )
    {
        var (evenCount, oddCount) = EvenOdd.CountEvenOdd([.. numbers]);
        Assert.Equal(expectedEvenCount, evenCount);
        Assert.Equal(expectedOddCount, oddCount);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
    [InlineData(new[] { 2, 1, 4, 3, 6, 5 }, new[] { 2, 1, 4, 3, 6, 5 })]
    [InlineData(new[] { 1, 1, 2, 2, 3, 3 }, new[] { 1, 2 })]
    [InlineData(new[] { 2, 2, 1, 1, 3, 3 }, new[] { 2, 1 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new[] { 1, 2, 3, 4, 5 })]
    [InlineData(new[] { 2, 1, 4, 3, 6, 5, 8, 7, 10, 9 }, new[] { 2, 1, 4, 3, 6 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, new[] { 1, 2, 3, 4, 5 })]
    [InlineData(new[] { 2, 1, 4, 3, 6, 5, 8, 7, 10, 9, 12, 11 }, new[] { 2, 1, 4, 3, 6 })]
    [InlineData(
        new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }
    )]
    [InlineData(new[] { -1, 2, -3, 4, -5, 6 }, new[] { -1, 2, -3, 4, -5, 6 })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 2 }, new[] { 2 })]
    [InlineData(
        new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
        new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }
    )]
    public void FindLongestAlternatingSequence_ShouldReturnCorrectSequence(
        int[] numbers,
        int[] expected
    ) => Assert.Equal(expected, EvenOdd.FindLongestAlternatingSequence([.. numbers]));
}
