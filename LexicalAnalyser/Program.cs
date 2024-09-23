static class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length != 1)
            {
                throw new ApplicationException("Wrong number of arguments.");
            }

            var analyser = new LexicalAnalyser.LexicalAnalyser(args[0]);
            var result = analyser.Tokenize();
            
            Console.Write(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

