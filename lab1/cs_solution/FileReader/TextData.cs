using System.Text.RegularExpressions;

record TextData(
    string FileName,
    string Text,
    int NumberOfVowels,
    int NumberOfConsonants,
    int NumberOfLetters,
    int NumberOfSentences,
    string LongestWord
)
{
    public static TextData FromText(string fileName, string text)
    {
        int vowels = CountVowels(text);
        int consonants = CountConsonants(text);
        int letters = vowels + consonants;
        int sentences = CountSentences(text);
        string? longestWord = FindLongestWord(text);

        return new TextData(fileName, text, vowels, consonants, letters, sentences, longestWord ?? "");
    }

    private static int CountVowels(string text) => text.Count(c => "AEIOUaeiou".Contains(c));
    private static int CountConsonants(string text) => text.Count(c => char.IsLetter(c) && !"AEIOUaeiou".Contains(c));
    private static int CountSentences(string text) => Regex.Matches(text, @"[.!?]").Count;
    private static string? FindLongestWord(string text)
    {
        var words = Regex.Split(text, @"\W+").Where(w => w.Length > 0);
        return words.OrderByDescending(w => w.Length).FirstOrDefault();
    }
}
