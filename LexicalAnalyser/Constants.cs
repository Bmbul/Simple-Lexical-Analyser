namespace LexicalAnalyser;

public static class Constants
{
    public const int MaxLexemLength = 50;

    public static readonly List<String> Keywords = new (){ "var", "begin", "end" };
    public static readonly List<String> LexicalTokens = new (){ "+", "-", ":=", ":", ";", "."};
    
    public static readonly Dictionary<string, LexicalToken> LexemsToTypes = new()
    {
        { "+", LexicalToken.Plus },
        { "-", LexicalToken.Minus },
        { ":=", LexicalToken.Assignment },
        { ":", LexicalToken.Colon },
        { ";", LexicalToken.Semicolon },
        { ".", LexicalToken.Dot },
        { "var", LexicalToken.VarKeyword },
        { "begin", LexicalToken.BeginKeyword },
        { "end", LexicalToken.EndKeyword }
    };
};
