namespace AlgoTester.Tests;

public class AnagramsTests
{
    [Theory]
    [InlineData("Listen", "siLent", true)]
    [InlineData("baseball", "parachute", false)]
    [InlineData("trash", "computer", false)]
    [InlineData("hello", "world", false)]
    [InlineData("triangle", "integral", true)]
    [InlineData("apple", "papel", true)]
    [InlineData("rat", "car", false)]
    public void AreAnagramButCleaner_ShouldReturnCorrectResult(string a, string b, bool expected) =>
        Assert.Equal(expected, Anagrams.AreAnagramButCleaner(a, b));

    [Theory]
    [InlineData(
        "listen",
        new[] { "silent", "enlist", "tinsel", "google" },
        new[] { "silent", "enlist", "tinsel" }
    )]
    [InlineData("rat", new[] { "tar", "art", "car" }, new[] { "tar", "art" })]
    [InlineData("bat", new[] { "tab", "cat", "abt", "tba" }, new[] { "tab", "abt", "tba" })]
    [InlineData(
        "hello",
        new[] { "world", "olleh", "hlloe", "oellh" },
        new[] { "olleh", "hlloe", "oellh" }
    )]
    [InlineData("dog", new[] { "god", "cat", "odg", "gdo" }, new[] { "god", "odg", "gdo" })]
    public void FindAnagrams_ShouldReturnCorrectAnagrams(
        string word,
        string[] words,
        string[] expected
    ) => Assert.Equal(expected, Anagrams.FindAnagrams(word, words.ToList()));

    [Fact]
    public void GroupAnagrams_ShouldReturnCorrectGroups_ForListenExample() =>
        TestGroupAnagrams(
            ["listen", "silent", "enlist", "tinsel", "google"],
            [
                ["listen", "silent", "enlist", "tinsel"],
                ["google"],
            ]
        );

    [Fact]
    public void GroupAnagrams_ShouldReturnCorrectGroups_ForRatExample() =>
        TestGroupAnagrams(
            ["rat", "tar", "art", "car"],
            [
                ["rat", "tar", "art"],
                ["car"],
            ]
        );

    [Fact]
    public void GroupAnagrams_ShouldReturnCorrectGroups_ForBatExample() =>
        TestGroupAnagrams(
            ["bat", "tab", "cat", "abt", "tba"],
            [
                ["bat", "tab", "abt", "tba"],
                ["cat"],
            ]
        );

    [Fact]
    public void GroupAnagrams_ShouldReturnCorrectGroups_ForDogExample() =>
        TestGroupAnagrams(
            ["dog", "god", "cat", "odg", "gdo"],
            [
                ["dog", "god", "odg", "gdo"],
                ["cat"],
            ]
        );

    [Fact]
    public void GroupAnagrams_ShouldReturnCorrectGroups_ForAbcExample() =>
        TestGroupAnagrams(
            ["abc", "bca", "cab", "xyz", "zyx", "yxz"],
            [
                ["abc", "bca", "cab"],
                ["xyz", "zyx", "yxz"],
            ]
        );

    private static void TestGroupAnagrams(string[] words, List<List<string>> expected)
    {
        var result = Anagrams.GroupAnagrams([.. words]);
        Assert.Equal(expected.Count, result.Count);
        for (var i = 0; i < expected.Count; i++)
            Assert.Equal(expected[i].OrderBy(x => x), result[i].OrderBy(x => x));
    }
}
