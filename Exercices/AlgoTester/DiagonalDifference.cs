namespace exercices;

public static class DiagonalDifference
{
    private static int Exec(List<List<int>> arr)
    {
        var (left, right) = (0, 0);
        for (int i = 0; i < arr.Count; i++)
        {
            left += arr[i][i];
            right += arr[i][arr.Count - i - 1];
        }
        return Math.Abs(left - right);
    }

    public static void Run()
    {
        var tests = new List<(List<List<int>>, int)>
        {
            ( [[1, 2, 3], [4, 5, 6], [9, 8, 9]], 2),
            ( [[11, 2, 4], [4, 5, 6], [10, 8, -12]], 15),
            ( [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12], [13, 14, 15, 16]], 0),
            ( [[1, 8], [2, 3]], 6)
        };

        foreach (var (arr, expected) in tests)
            Console.WriteLine(Exec(arr) == expected ? "OK" : "ERROR");
    }
}
