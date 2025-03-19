namespace AlgoTester.Tests;

public class DiagonalDifferenceTests
{
    [Fact]
    public void Exec_ShouldReturnCorrectDifference_For3x3Matrix() =>
        Assert.Equal(
            2,
            DiagonalDifference.Exec(
                [
                    [1, 2, 3],
                    [4, 5, 6],
                    [9, 8, 9],
                ]
            )
        );

    [Fact]
    public void Exec_ShouldReturnCorrectDifference_For3x3MatrixWithNegative() =>
        Assert.Equal(
            15,
            DiagonalDifference.Exec(
                [
                    [11, 2, 4],
                    [4, 5, 6],
                    [10, 8, -12],
                ]
            )
        );

    [Fact]
    public void Exec_ShouldReturnCorrectDifference_For4x4Matrix() =>
        Assert.Equal(
            0,
            DiagonalDifference.Exec(
                [
                    [1, 2, 3, 4],
                    [5, 6, 7, 8],
                    [9, 10, 11, 12],
                    [13, 14, 15, 16],
                ]
            )
        );

    [Fact]
    public void Exec_ShouldReturnCorrectDifference_For2x2Matrix() =>
        Assert.Equal(
            0,
            DiagonalDifference.Exec(
                [
                    [1, 2],
                    [3, 4],
                ]
            )
        );
}
