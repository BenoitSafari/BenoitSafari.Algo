namespace AlgoTester.Tests;

public class PrimeNumbersTests
{
    [Theory]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(5, true)]
    [InlineData(6, false)]
    [InlineData(7, true)]
    [InlineData(8, false)]
    [InlineData(9, false)]
    [InlineData(10, false)]
    [InlineData(11, true)]
    public void IsPrime_ShouldReturnCorrectResult(int number, bool expected) =>
        Assert.Equal(expected, PrimeNumbers.IsPrime(number));

    [Theory]
    [InlineData(10, new[] { 2, 3, 5, 7 })]
    [InlineData(20, new[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
    [InlineData(30, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 })]
    public void ListPrimes_ShouldReturnCorrectPrimes(int limit, int[] expected) =>
        Assert.Equal(expected, PrimeNumbers.ListPrimes(limit));

    [Theory]
    [InlineData(4, 2, 2)]
    [InlineData(6, 3, 3)]
    [InlineData(8, 3, 5)]
    [InlineData(10, 3, 7)]
    [InlineData(12, 5, 7)]
    [InlineData(14, 3, 11)]
    [InlineData(16, 3, 13)]
    [InlineData(18, 5, 13)]
    [InlineData(20, 3, 17)]
    public void FindGoldbachSum_ShouldReturnCorrectPrimes(
        int evenNumber,
        int expectedFirst,
        int expectedSecond
    )
    {
        var result = PrimeNumbers.FindGoldbachSum(evenNumber);
        Assert.NotNull(result);
        Assert.Equal(expectedFirst, result.Value.prime1);
        Assert.Equal(expectedSecond, result.Value.prime2);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(7)]
    [InlineData(9)]
    [InlineData(11)]
    public void FindGoldbachSum_ShouldReturnNullForOddNumbers(int oddNumber) =>
        Assert.Null(PrimeNumbers.FindGoldbachSum(oddNumber));
}
