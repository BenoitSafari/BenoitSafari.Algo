namespace exercices;


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
        for (int i = 0; i < a.Length; i++)
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

        for (int i = 0; i < strA.Length; i++)
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
        foreach(var str in words)
        {
            if (result.Any(x => x.Contains(str)))
                continue;
            var matchs = words.Where(x => AreAnagram(x, str) && x != str);
            result.Add(matchs.Any() ? [..matchs, str] : [str]); 
        }
        return result;
    }

    public static void Run()
    {
        foreach (var (payload, expected) in new List<((string, string), bool)>
        {
            (("Listen", "siLent"), true),
            (("baseball", "parachute"), false),
            (("trash", "computer"), false),
            (("hello", "world"), false),
            (("triangle", "integral"), true),
            (("apple", "papel"), true),
            (("rat", "car"), false)
        })
            if (AreAnagramButCleaner(payload.Item1, payload.Item2) != expected) 
                throw new Exception();
        
        // foreach (var (word, words, expected) in new List<(string, List<string>, List<string>)>
        // {
        //     ("listen", new List<string> {"silent", "enlist", "tinsel", "google"}, new List<string> {"silent", "enlist", "tinsel"}),
        //     ("rat", new List<string> {"tar", "art", "car"}, new List<string> {"tar", "art"}),
        //     ("bat", new List<string> {"tab", "cat", "abt", "tba"}, new List<string> {"tab", "abt", "tba"}),
        //     ("hello", new List<string> {"world", "olleh", "hlloe", "oellh"}, new List<string> {"olleh", "hlloe", "oellh"}),
        //     ("dog", new List<string> {"god", "cat", "odg", "gdo"}, new List<string> {"god", "odg", "gdo"})
        // })
        //     if (FindAnagrams(word, words).SequenceEqual(expected))
        //         throw new Exception();

        // foreach (var (words, expected) in new List<(List<string>, List<List<string>>)> 
        // {
        //     (new List<string> {"listen", "silent", "enlist", "tinsel", "google"}, new List<List<string>> { new() { "listen", "silent", "enlist", "tinsel"}, new() { "google"} }),
        //     (new List<string> {"rat", "tar", "art", "car"}, new List<List<string>> { new() { "rat", "tar", "art"}, new() { "car"} }),
        //     (new List<string> {"bat", "tab", "cat", "abt", "tba"}, new List<List<string>> { new() { "bat", "tab", "abt", "tba"}, new() { "cat"} }),
        //     (new List<string> {"dog", "god", "cat", "odg", "gdo"}, new List<List<string>> { new() { "dog", "god", "odg", "gdo"}, new() { "cat"} }),
        //     (new List<string> {"abc", "bca", "cab", "xyz", "zyx", "yxz"}, new List<List<string>> { new() { "abc", "bca", "cab"}, new() { "xyz", "zyx", "yxz"} })
        // })
        //     GroupAnagrams(words);
    }
}
