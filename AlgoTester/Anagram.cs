namespace AlgoTester;

public static class Anagrams
{
    public static bool AreAnagram(string a, string b) // O(n log n)
    {
        var result = true;

        if (a.Length != b.Length)
        {
            result = false;
            return result;
        }

        var lettersA = a.ToLower().OrderBy(x => x).ToArray();
        var lettersB = b.ToLower().OrderBy(x => x).ToArray();
        for (var i = 0; i < a.Length; i++)
        {
            if (lettersA[i] != lettersB[i])
            {
                result = false;
                break;
            }
        }

        return result;
    }

    public static bool AreAnagramButCleaner(string a, string b) // O(n)
    {
        if (a.Length != b.Length)
            return false;

        var strA = a.ToLower();
        var strB = b.ToLower();
        var count = new int[26];

        for (var i = 0; i < strA.Length; i++)
        {
            count[strA[i] - 'a']++;
            count[strB[i] - 'a']--;
        }

        return count.All(x => x == 0);
    }

    public static List<string> FindAnagrams(string word, List<string> words) =>
        [.. words.Where(x => AreAnagram(x, word))];

    public static List<List<string>> GroupAnagrams(List<string> words)
    {
        var result = new List<List<string>>();
        foreach (var str in words)
        {
            if (result.Any(x => x.Contains(str)))
                continue;
            var matchs = words.Where(x => AreAnagram(x, str) && x != str);
            result.Add(matchs.Any() ? [.. matchs, str] : [str]);
        }
        return result;
    }
}
