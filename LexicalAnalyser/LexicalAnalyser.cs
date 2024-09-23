using System.Text;

namespace LexicalAnalyser;

public class LexicalAnalyser(string filePath)
    {
        private readonly LexicalAnalyserResult _result = new ();
        private readonly IFileReader _fileReader = new FileReader();
        private readonly IStringSplitter _stringSplitter = new StringSplitter();
        
        public LexicalAnalyserResult Tokenize()
        {
            var fileContent = _fileReader.ReadFile(filePath);
            var splittedWords = _stringSplitter.SplitContent(fileContent);
            
            foreach (var word in splittedWords)
            {
                AnalyseWord(word);
            }

            return _result;
        }

        public void AnalyseWord(string word)
        {
            if (word.TryGetFirstLexem(out (int offset, int length) foundToken))
                ProcessFoundToken(word, foundToken);
            else
                ProcessOtherTypes(word);
        }

        private void ProcessFoundToken(string word, (int offset, int length) foundToken)
        {
            if (foundToken.offset > 0)
                AnalyseWord(word.Substring(0, foundToken.offset));
            
            _result.AddElement(LexemType.LexemSymbols, word.Substring(foundToken.offset, foundToken.length));

            var remaining = word.Substring(foundToken.offset + foundToken.length);
            if (!string.IsNullOrEmpty(remaining))
                AnalyseWord(remaining);
        }

        private void ProcessOtherTypes(string word)
        {
            switch (true)
            {
                case var _ when word.IsKeyword():
                    _result.AddElement(LexemType.LexemSymbols, word);
                    break;

                case var _ when word.IsIdentifier():
                    _result.AddElement(LexemType.Identifier, word);
                    break;

                case var _ when word.IsNumeric():
                    _result.AddElement(LexemType.Number, word);
                    break;

                default:
                    _result.AddElement(LexemType.Undefined, word);
                    break;
            }
        }
        
        public class LexicalAnalyserResult
        {
            private readonly List<(LexemType Type, string Value)> _parsedTokens = new ();

            public void AddElement(LexemType type, string value)
            {
                if (value.Length > Constants.MaxLexemLength)
                {
                    throw new ApplicationException($"Too long scanning. The scanning word: {value}, with the length: {value.Length}.\nThe maximum allowed length is {Constants.MaxLexemLength}.");
                }
                _parsedTokens.Add((type, value));    
            }

            public override string ToString()
            {
                var resultString = new StringBuilder();
                var invalidTermMessage = "error, invalid term";

                foreach (var parsedToken in _parsedTokens)
                {
                    resultString.AppendLine(parsedToken.Type switch
                    {
                        LexemType.Undefined => $"{parsedToken.Value}: {invalidTermMessage}",
                        _ => $"{parsedToken.Type}: \"{parsedToken.Value}\""
                    });
                }
                return resultString.ToString();
            }
        }
    }