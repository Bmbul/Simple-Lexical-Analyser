namespace LexicalAnalyser;

public static class StringExtentions
{
    public static bool IsNumeric(this string str)
    {
        return !string.IsNullOrEmpty(str) && str.All(char.IsDigit);
    }
    
    public static bool IsIdentifier(this string str)
    {
        return !string.IsNullOrEmpty(str) && str[0].IsLetter() && str.All(x => x.IsDigitOrLetter());
    }

    public static bool IsKeyword(this string str)
    {
        return Constants.Keywords.Contains(str);
    }

    public static bool TryGetFirstLexem(this string word, out (int Offset, int Length) foundLexem)
    {
        foundLexem = default;
        for (int i = 0; i < word.Length; i++)
        {
            var subString = word.Substring(i);
            foreach (var token in Constants.LexicalTokens)
            {
                if (subString.StartsWith(token))
                {
                    foundLexem = (i, token.Length);
                    return true;
                }
            }
        }
        return false;
    }
    
    public static bool IsDigit(this char ch) =>  char.IsDigit(ch);
    
    public static bool IsLetter(this char ch) => char.IsLetter(ch);

    public static bool IsDigitOrLetter(this char ch) => ch.IsDigit() || ch.IsLetter();
}