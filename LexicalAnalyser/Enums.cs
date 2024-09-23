namespace LexicalAnalyser;

public enum LexemType
{
    Undefined,
    Identifier,
    Number,
    LexemSymbols
}

public enum LexicalToken
{
    Unknown,        // default value
    Plus,           // +
    Minus,          // -
    Assignment,     // :=
    Colon,          // :
    Semicolon,      // ;
    Dot,            // .
    VarKeyword,     // var
    BeginKeyword,   // begin
    EndKeyword      // end
}