namespace LexicalAnalyser;

public interface IFileReader
{
    string ReadFile(string filePath);
}

public class FileReader : IFileReader
{
    public string ReadFile(string filePath)
    {
        return File.ReadAllText(filePath).Trim();
    }
}