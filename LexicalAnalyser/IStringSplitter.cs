namespace LexicalAnalyser;

public interface IStringSplitter
{
    string[] SplitContent(string content);
}

public class StringSplitter : IStringSplitter
{
    private static readonly char[] Separators = [' ', '\n'];
    
    public string[] SplitContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return [];
        }
        
        var splittedContent = content.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
        return splittedContent;
    }
}