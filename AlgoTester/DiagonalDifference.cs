namespace AlgoTester;

public static class DiagonalDifference
{
    public static int Exec(List<List<int>> arr)
    {
        var (left, right) = (0, 0);
        for (var i = 0; i < arr.Count; i++)
        {
            left += arr[i][i];
            right += arr[i][arr.Count - i - 1];
        }
        return Math.Abs(left - right);
    }
}
