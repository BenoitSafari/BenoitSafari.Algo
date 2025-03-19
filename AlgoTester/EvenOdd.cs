namespace AlgoTester;

public static class EvenOdd
{
    public static bool IsEven(int number) => number % 2 == 0;

    public static (int evenCount, int oddCount) CountEvenOdd(List<int> numbers)
    {
        var result = (evenCount: 0, oddCount: 0);
        foreach (var n in numbers)
            if (IsEven(n))
                result.evenCount++;
            else
                result.oddCount++;

        return result;
    }

    public static List<int> FindLongestAlternatingSequence(List<int> numbers)
    {
        var result = new List<int>();
        var sequence = new List<int>();

        for (var i = 0; i < numbers.Count; i++)
        {
            var number = numbers[i];
            if (i == 0 || sequence.Count == 0)
            {
                sequence.Add(number);
                continue;
            }
            if (IsEven(sequence.Last()) != IsEven(number))
            {
                sequence.Add(number);
                if (i != numbers.Count - 1)
                    continue;
            }
            if (result.Count < sequence.Count)
            {
                result = sequence.ToList();
            }
            sequence.Clear();
        }

        return result;
    }
}
